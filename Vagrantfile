Vagrant.configure("2") do |config|
  
  # Define the Linux VM
  config.vm.define "linux" do |linux|
    linux.vm.box = "ubuntu/bionic64" # Ubuntu 18.04
    linux.vm.hostname = "linux-labmanager"
    linux.vm.network "private_network", type: "dhcp"
    linux.vm.provider "virtualbox" do |vb|
      vb.memory = "2048"
      vb.cpus = 2
    end
    linux.vm.provision "shell", inline: <<-SHELL
      # Update and install dependencies
      apt-get update
      apt-get install -y wget apt-transport-https software-properties-common

      # Install .NET SDK
      wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      dpkg -i packages-microsoft-prod.deb
      apt-get update
      apt-get install -y dotnet-sdk-8.0

      # Configure NuGet to use BaGet
      mkdir -p ~/.nuget/NuGet
      cat <<EOF > ~/.nuget/NuGet/NuGet.Config
      <configuration>
        <packageSources>
          <add key="BaGet" value="http://<your-baget-url>/v3/index.json" />
        </packageSources>
      </configuration>
      EOF

      # Install LabManager global tool
      dotnet tool install --global <package-name> --version <version>

      # Ensure dotnet tools are in PATH
      echo 'export PATH="$PATH:/root/.dotnet/tools"' >> ~/.bashrc
      source ~/.bashrc

      # Navigate to the project directory (assuming shared folder)
      cd /vagrant

      # Run build commands
      LabManager.exe build 1
      LabManager.exe build 2
      LabManager.exe build 3

      # Run commands
      LabManager.exe run 1
      LabManager.exe run 2
      LabManager.exe run 3

      # Test commands
      LabManager.exe test 1
      LabManager.exe test 2
      LabManager.exe test 3
    SHELL
  end

  # Define the macOS VM
  config.vm.define "macos" do |mac|
    mac.vm.box = "peru/macos-mojave" # Example macOS box; replace with your own
    mac.vm.hostname = "macos-labmanager"
    mac.vm.network "private_network", type: "dhcp"
    mac.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"
      vb.cpus = 2
    end
    mac.vm.provision "shell", inline: <<-SHELL
      # Install Homebrew if not installed
      if ! command -v brew &> /dev/null
      then
          /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
      fi

      # Install .NET SDK
      brew install --cask dotnet-sdk

      # Configure NuGet to use BaGet
      mkdir -p ~/.nuget/NuGet
      cat <<EOF > ~/.nuget/NuGet/NuGet.Config
      <configuration>
        <packageSources>
          <add key="BaGet" value="http://<your-baget-url>/v3/index.json" />
        </packageSources>
      </configuration>
      EOF

      # Install LabManager global tool
      dotnet tool install --global <package-name> --version <version>

      # Ensure dotnet tools are in PATH
      echo 'export PATH="$PATH:/Users/vagrant/.dotnet/tools"' >> ~/.bash_profile
      source ~/.bash_profile

      # Navigate to the project directory (assuming shared folder)
      cd /vagrant

      # Run build commands
      LabManager.exe build 1
      LabManager.exe build 2
      LabManager.exe build 3

      # Run commands
      LabManager.exe run 1
      LabManager.exe run 2
      LabManager.exe run 3

      # Test commands
      LabManager.exe test 1
      LabManager.exe test 2
      LabManager.exe test 3
    SHELL
  end

  # Define the Windows VM
  config.vm.define "windows" do |win|
    win.vm.box = "mwrock/Windows2016" # Windows Server 2016
    win.vm.hostname = "windows-labmanager"
    win.vm.network "private_network", type: "dhcp"
    win.vm.communicator = "winrm"
    win.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"
      vb.cpus = 2
    end
    win.vm.provision "shell", inline: <<-SHELL
      # Install Chocolatey if not installed
      Set-ExecutionPolicy Bypass -Scope Process -Force;
      [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072;
      iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

      # Install .NET SDK
      choco install dotnetcore-sdk -y

      # Configure NuGet to use BaGet
      New-Item -Path "$env:APPDATA\NuGet" -ItemType Directory -Force
      $nugetConfig = @"
      <configuration>
        <packageSources>
          <add key="BaGet" value="http://<your-baget-url>/v3/index.json" />
        </packageSources>
      </configuration>
      "@
      $nugetConfig | Out-File -FilePath "$env:APPDATA\NuGet\NuGet.Config" -Encoding utf8

      # Install LabManager global tool
      dotnet tool install --global <package-name> --version <version>

      # Ensure dotnet tools are in PATH
      $env:Path += ";$env:USERPROFILE\.dotnet\tools"
      [Environment]::SetEnvironmentVariable("Path", $env:Path, [EnvironmentVariableTarget]::Machine)

      # Navigate to the project directory (assuming shared folder)
      cd /vagrant

      # Run build commands
      LabManager.exe build 1
      LabManager.exe build 2
      LabManager.exe build 3

      # Run commands
      LabManager.exe run 1
      LabManager.exe run 2
      LabManager.exe run 3

      # Test commands
      LabManager.exe test 1
      LabManager.exe test 2
      LabManager.exe test 3
    SHELL
  end

end
