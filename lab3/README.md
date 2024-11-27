## Завдання для всіх варіантів

#### Послідовність дій:

1. Для початку треба було скачати nuget i додати до змінних середовища шлях до папки з nuget, щоб nuget працював в cmd/powershell.

2. Створюємо новий проект бібліотеки класів:

```bash
dotnet new classlib -n Lab3ClassLibrary
```

3. Додаємо код

4. Пакуємо проект в NuGet пакет, після чого він з'явиться в папці bin\Debug або bin\Release:

```bash
dotnet pack
```

5. Додаємо пакет в локальний репозиторій:

```bash
nuget add ALibrary.1.0.0.nupkg -source C:\NugetLocal
```

6. В Visual Studio заходимо в **Tools** > **Package Manager Settings** > **NuGet Package Manager** > **Package Sources** і додаємо новий локальний репозиторій.

7. Встановлюємо пакет через **Visual Studio** або **NuGet Package Manager**:

```bash
dotnet add Lab3/Lab3.csproj package ALibrary --version <version_number>
```
