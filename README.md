Business Email Checker
[![Build status](https://ci.appveyor.com/api/projects/status/vpcr2lhdo4cvukv5/branch/master?svg=true)](https://ci.appveyor.com/project/salaros/is-biz-mail-dotnet/branch/master)
[![AppVeyor tests branch](https://img.shields.io/appveyor/tests/salaros/is-biz-mail-dotnet/master.svg)](https://ci.appveyor.com/project/salaros/is-biz-mail-dotnet/build/tests)
[![Coverage Status](https://coveralls.io/repos/github/salaros/is-biz-mail-dotnet/badge.svg?branch=master)](https://coveralls.io/github/salaros/is-biz-mail-dotnet?branch=master)
======================
[![License](https://img.shields.io/github/license/salaros/is-biz-mail-dotnet.svg)](https://github.com/salaros/is-biz-mail-dotnet/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Salaros.Email.IsBizMail.svg?label=NuGet&colorA=404680&colorB=98976B)](https://www.nuget.org/packages/Salaros.Email.IsBizMail)
[![NuGet](https://img.shields.io/nuget/dt/Salaros.Email.IsBizMail.svg)](https://www.nuget.org/packages/Salaros.Email.IsBizMail)
[![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.0+-784877.svg)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support)

**isBizMail** tells you whether a given email address is free (gmail.com, yahoo.es, yandex.ru etc) or not.
The list of emails used by **isBizMail** is taken from [here](http://svn.apache.org/repos/asf/spamassassin/trunk/rules/20_freemail_domains.cf)¹.
Detects around 2500 domains and subdomains.

1) *All credits for the list itself go to [SpamAssasin](https://spamassassin.apache.org/) authors and contributors*

### Installation

You can install IsBizMail for **.NET Core 2.0+ / Framework 4.6.1+, Mono 5.4+** etc via [NuGet](https://www.nuget.org/packages/Salaros.Email.IsBizMail/).

You could build it from sources via:

```bash
dotnet build
```

IsBizMail in .NET is a static class, so can use it like this:

```cs
using Salaros.Email;

//..
{
    Console.WriteLine(IsBizMail.IsValid("foo@bar.com"));        // true
    Console.WriteLine(IsBizMail.IsValid("hello@gmail.com"));    // false
}
//..

```

### Testing: xUnit.net

```bash
dotnet test tests
```
