# pothole-detection-project - detectar ruas esburacadas

🚧 TrepidaApp

TrepidaApp é um aplicativo mobile desenvolvido em .NET MAUI que tem como objetivo identificar ruas esburacadas ou com muita trepidação. 

O app utiliza o acelerômetro e o GPS do dispositivo para capturar os dados de vibração e localização em tempo real, e os armazena localmente em um banco de dados SQLite.

📱 Funcionalidade Principal

O aplicativo faz:

📡 Captura da Localização GPS
📊 Leitura do Acelerômetro
🎯 Cálculo da intensidade da trepidação
🗃️ Armazenamento local dos dados no SQLite

Esses dados podem ser utilizados posteriormente para:

1. Análise de qualidade das vias públicas
2. Visualização em mapa
3. Exportação para relatórios ou bancos de dados remotos

1. Coleta de dados de GPS
2. Coleta de dados do acelerômetro (para detectar trepidações)
3. Armazenamento em banco de dados SQLite local
4. Interface simples para iniciar/parar a coleta

📱 Tecnologias Utilizadas

Xamarin.Forms (para Android, multiplataforma)
Plugin.Geolocator (para localização GPS)
Xamarin.Essentials (acesso ao acelerômetro)
SQLite-net-pcl (banco local)

🛠️ Ferramentas de Desenvolvimento

Visual Studio 2022 ou 2025
Emulador Android ou Dispositivo físico
.NET SDK 7 ou 8 (dependendo do template usado)

🧠 Lógica de Trepidação
A intensidade da trepidação é calculada com base na fórmula:
√(X² + Y² + (Z - 1)²)

🔜 Próximos Passos

1. Visualizar os dados num mapa (com pins em locais de trepidação)
2. Exportar CSV
3. Sincronizar com API remota
