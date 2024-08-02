---
redirect_url: api/JohnsonControls.Metasys.BasicServices.html
---

<!-- TODO: Create a real introduction page here and remove the redirect_url at the top of this page. Then update the toc.yml file to include API and Docs (once we have docs) -->

# Metasys Basic Services Documentation

This site provides you with articles, guides, and API documentation to help you
write applications that integrate with Metasys.

## Authenticating

The Basic Services Library has support for common credential managers.

# [Windows](#tab/windows)

On Windows the Credential Manager store is supported.

You can record your passwords using `metasys-secrets` cli application.

### First install the application

```bash
dotnet tool install -g JohnsonControls.MetasysSecrets
```

Now save your password in Windows Credential Manager

```bash
# replace my-ads.company.com with the domain name of your server
# replace serviceAccount with the user name of the account you want to use
metasys-secrets store my-ads.company.com serviceAccount
```

You will then be prompted for your password.

Now in your application you can use `SecretStore` to retrieve your password.

[!code-csharp[](includes/TryLogin.cs?highlight=3)]

<!-- ```csharp?highlight=2=========
var x = 5;
var y = 6;
Console.WriteLine(x);

``` -->

# [Linux](#tab/linux)

On Linux the libsecret store is supported.

# [macOS](#tab/macOS)

On macOS, the Keychain store is supported

---
