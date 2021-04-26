# Ecad - Teste
API Restful desenvolvida como parte de solução para processo seletivo da Ecad.


### Sobre o Desenvolvimento da Solução
Solução desenvolvida com Visual Studio 2019 Community, utilizando .Net Core 3.1
- Banco de Dados LocalDb SQL Server
- DDD
- Code First
- Injeção de dependência
- Automapper


### Documentação da API
A documentação da API foi feita utilizando-se o swagger.  Para visualizá-la, é necessário saber em qual porta a API será executada.  
```
URL: https://servidor:porta/swagger
```

- Foram criados 4 endpoints utilizando-se a arquitetura Restfull, todas elas fazendo uso dos 4 verbos mais usados do protocolo HTTP: GET, POST, PUT e DELETE: Genero, Categoria, Autor e Musica.

1. Recuperando todos os registros.
```
URL: https://servidor:porta/api/endpoint (ex.: https://localhost:44364/api/musica)
Verbo: GET
```

2. Recuperando um registro específico
```
URL: https://servidor:porta/api/endpoint/{id} (ex.: https://localhost:44364/api/musica/aaa-bbb-ccc)
Verbo: GET
```

3. Incluindo um registro
```
URL: https://servidor:porta/api/endpoint (ex.: https://localhost:44364/api/musica)
Verbo: POST
Body: passar o JSon correspondente (pode ser consultado no swagger)    
```

4. Alterando um cliente
```
URL: https://servidor:porta/api/endpoint/{id} (ex.: https://localhost:44364/api/musica/aaa-bbb-ccc)
Verbo: PUT
Body: passar o JSon correspondente (pode ser consultado no swagger)    
```

5. Excluindo um cliente
```
URL: https://servidor:porta/api/endpoint/{id} (ex.: https://localhost:44364/api/musica/aaa-bbb-ccc)
Verbo: DELETE
```


### Autor/Data
Flavio Rianelli
Abril/2021
