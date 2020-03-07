# kafka-example-chat
📨 Exemplo de aplicação de chat utilizando Kafka

Esta aplicação demonstra o uso básico do Apache Kafka para uma aplicação de Chat. A aplicação contém um `Consumer` e um `Producer`, permitindo assim, enviar e receber mensagens. O Kafka, Zookeeper e KafkaTopicsUI sobem via arquivo docker-compose, criado baseando-se no projeto [kafka-stack-docker-compose](https://github.com/simplesteph/kafka-stack-docker-compose).

Para subir a estrutura Kafka, basta rodar o CMD na pasta Docker:

```dockerfile
docker-compose up --build -d
```
Após isso, é só executar o projeto. Executando várias instâncias você consegue fazer um bate-papo ☺

Para visualizar as mensagens que chegam no Kafka, pode abrir no navegador o Kafka Topics UI: http://localhost:8000/

| CodeFactor |
|:---:|
|[![CodeFactor](https://www.codefactor.io/repository/github/rafaeldalsenter/kafka-example-chat/badge)](https://www.codefactor.io/repository/github/rafaeldalsenter/kafka-example-chat)|
