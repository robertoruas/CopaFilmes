# Copa-Filmes

## Para executar os projetos é preciso

- Para executar esse projeto vamos precisar de dois prompt de comando (use o de usa preferencia, powershell, cmd, terminal)
- No prompt de comando entre na pasta copa-filmes-ui e execute npm install para baixar os pacotes necessários:
-- Se ocorrer algum problema, pode apagar a pasta node_modules (as informações importantes estão no arquivo package.json);
- Após a conclusão do download dos pacotes vamos para o próximo passo;
- Abra a segunda janela e entre na pasta copa-filmes-api e execute o comando dotnet restore, ele irá resturar todos os pacotes utilizados no programa;
- Após a conclusão, vamos para execução dos projetos!

- Na primeira janela de prompt, execute o comando npm start, ele irá inicializar o projeto e abrir o navegador com endereço http://localhost:3000;
- Na segunda janela de prompt, execute o comando dotnet run, ele irá inicializar o projeto e esse não abrirá nenhuma janela, mas ele responde ao endereço http://localhost:3001
-- Caso queira testar requisições diretamente na API, utilize o endereço http://localhost:3001/api/campeonato (só existe 1 método e de POST);