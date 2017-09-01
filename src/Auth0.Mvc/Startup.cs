using System;
using System.Collections.Generic;
using System.Linq;
#if (SignatureAlgorithm == "HS256")
using System.Text;
#endif
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
#if (IncludeProfilePage || SignatureAlgorithm == "HS256")
using Microsoft.IdentityModel.Tokens;
#endif

namespace Auth0.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
#if (SignatureAlgorithm == "HS256")
            // Get the client secret used for signing the tokens
            var keyAsBytes = Encoding.UTF8.GetBytes(Configuration["Auth0:ClientSecret"]);
            var issuerSigningKey = new SymmetricSecurityKey(keyAsBytes);
            
#endif
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                // Set the authority to your Auth0 domain
                options.Authority = $"https://{Configuration["Auth0:Domain"]}";

                // Configure the Auth0 Client ID and Client Secret
                options.ClientId = Configuration["Auth0:ClientId"];
                options.ClientSecret = Configuration["Auth0:ClientSecret"];

                // Set response type to code
                options.ResponseType = "code";

#if (SaveTokens)
                // Save tokens to the AuthenticationProperties
                options.SaveTokens = true;
                
#endif
                // Configure the scope
                options.Scope.Clear();
                options.Scope.Add("openid");
#if (IncludeProfilePage)
                options.Scope.Add("profile");
                options.Scope.Add("email");
#endif

                // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard 
                // e.g. http://localhost:5000/signin-auth0 
                options.CallbackPath = new PathString("/signin-auth0");

#if (!IncludeProfilePage && SignatureAlgorithm == "HS256")
                // Signature validation for HS256 signed token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = issuerSigningKey
                };

#endif
#if (IncludeProfilePage && SignatureAlgorithm == "RS256")
                // Signature validation for HS256 signed token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name"
                };

#endif
#if (IncludeProfilePage && SignatureAlgorithm == "HS256")
                // Signature validation for HS256 signed token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = issuerSigningKey,
                    NameClaimType = "name"
                };

#endif
                options.Events = new OpenIdConnectEvents
                {
                    // handle the logout redirection 
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                        // transform to absolute
                        var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
