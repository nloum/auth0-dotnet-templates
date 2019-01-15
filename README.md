# auth0-dotnet-templates
<img src="https://img.shields.io/badge/community-driven-brightgreen.svg"/> <br>

The Auth0 Templates for .NET Core allows you to quickly bootstrap a .NET Core Web application that works with Auth0.

This repo is supported and maintained by Community Developers, not Auth0. For more information about different support levels check https://auth0.com/docs/support/matrix .

## Getting started

### Requirements

* An Auth0 account
* .NET Core 2.0 SDK

### Installation

You can install the templates by running the following command

```bash
dotnet new -i Auth0.Templates
```

## Usage

### Auth0 MVC Application

To create a new MVC application, you can run the following command:

```
dotnet new auth0mvc [options]
```

This will create a new MVC application in the current folder. The following template-specific options are available:

Option | Description |
---------|----------
`-sa` or `--signature-algorithm` | The algorithm with which tokens returned from Auth0 are being signed. Can be either `RS256` or `HS256`. The default value is `RS256`
`-st` or `--save-tokens` | If specified, saves the tokens returned from Auth0. Can be either `true` or `false`. The default is `false`
`-pp` or `--include-profile-page` | If specified, adds a page which allows you to view the user's profile. Can be either `true` or `false`. The default is `true`
`-cp` or `--include-claims-page` | If specified, adds a page which allows you to view the user's claims. Can be either `true` or `false`. The default is `false`

### Auth0 Web API Application

To create a new Web API application, you can run the following command:

```
dotnet new auth0api [options]
```

This will create a new MVC application in the current folder. The following template-specific options are available:

Option | Description |
---------|----------
`-sa` or `--signature-algorithm` | The algorithm with which tokens returned from Auth0 are being signed. Can be either `RS256` or `HS256`. The default value is `RS256`
`-st` or `--save-tokens` | If specified, saves the tokens returned from Auth0. Can be either `true` or `false`. The default is `false`

## Contribute

Feel like contributing to this repo? We're glad to hear that! Before you start contributing please visit our [Contributing Guideline](https://github.com/auth0-community/getting-started/blob/master/CONTRIBUTION.md).

Here you can also find the [PR template](https://github.com/auth0-community/auth0-dotnet-templates/blob/master/PULL_REQUEST_TEMPLATE.md) to fill once creating a PR. It will automatically appear once you open a pull request.

## Issues Reporting

Spotted a bug or any other kind of issue? We're just humans and we're always waiting for constructive feedback! Check our section on how to [report issues](https://github.com/auth0-community/getting-started/blob/master/CONTRIBUTION.md#issues)!

Here you can also find the [Issue template](https://github.com/auth0-community/auth0-dotnet-templates/blob/master/ISSUE_TEMPLATE.md) to fill once opening a new issue. It will automatically appear once you create an issue.

## Repo Community

Feel like PRs and issues are not enough? Want to dive into further discussion about the tool? We created topics for each Auth0 Community repo so that you can join discussion on stack available on our repos. Here it is for this one: [auth0-dotnet-templates](https://community.auth0.com/t/auth0-community-oss-auth0-dotnet-templates/15987)

<a href="https://community.auth0.com/">
<img src="/assets/join_auth0_community_badge.png"/>
</a>

## License

This project is licensed under the MIT license. See the [LICENSE](https://github.com/auth0-community/auth0-dotnet-templates/blob/master/LICENSE) file for more info.

## What is Auth0?

Auth0 helps you to:

* Add authentication with [multiple authentication sources](https://docs.auth0.com/identityproviders), either social like
  * Google
  * Facebook
  * Microsoft
  * Linkedin
  * GitHub
  * Twitter
  * Box
  * Salesforce
  * etc.

  **or** enterprise identity systems like:
  * Windows Azure AD
  * Google Apps
  * Active Directory
  * ADFS
  * Any SAML Identity Provider

* Add authentication through more traditional [username/password databases](https://docs.auth0.com/mysql-connection-tutorial)
* Add support for [linking different user accounts](https://docs.auth0.com/link-accounts) with the same user
* Support for generating signed [JSON Web Tokens](https://docs.auth0.com/jwt) to call your APIs and create user identity flow securely
* Analytics of how, when and where users are logging in
* Pull data from other sources and add it to user profile, through [JavaScript rules](https://docs.auth0.com/rules)

## Create a free Auth0 account

* Go to [Auth0 website](https://auth0.com/signup)
* Hit the **SIGN UP** button in the upper-right corner
