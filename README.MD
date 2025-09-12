## HTTPS inside the local container

Export dev certificate for local development using the following command

```shell
dotnet dev-certs https --export-path ./https/aspnetapp.pfx -p MySecretPassword
```

Note: the password and the file name are hardcoded in the project
