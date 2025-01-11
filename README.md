# Auth Service
Это гибкий и встраиваемый сервис аутентификации пользователей  
Этот сервис легко интегрируется в микросервисную архитектуру  

## Настройка сервиса
Настроить сервис можно с помощью следующих файлов конфигурации:
* **appsettings.json** - конфигурация и настройка API
* **compose.{environment}.yml** - конфигурация взаимодействия API с остальными сервисами

## Запуск сервиса в локальной среде
Для запуска сервиса вам нужны следующие инструменты: Docker и Docker Compose  

Запуск Development версии:
```bash
docker compose -f compose.yml -f compose.development.yml up -d
```
Запуск Production версии:
```bash
docker compose -f compose.yml -f compose.production.yml up -d
```

## Стек технологий
* **Web API**: ASP.NET Core
* **База данных**: PostgreSQL
* **Кэш-сервер**: Redis
* **Контейнеризация**: Docker, Docker Compose
* **Локальный SMTP-сервер**: Papercut

## Библиотеки и фреймворки
* **Entity Framework Core** - для подключения к базе данных
* **MediatR** - для реализации CQRS
* **Fluent Validation** - для валидации входных данных
* **Mapperly** - для маппинга моделей
* **Swagger** - для документирования API
* **FluentEmail.Smtp** - для связи с SMTP-сервером
* **Microsoft.Extensions.Caching.StackExchangeRedis** - для подключения к кэш-серверу
* **BCrypt.Net-Next** - для хеширования паролей пользователей

## Архитектурные подходы
* **MVC**
* **Clean Architecture**
* **CQRS**
* **Mediator**
