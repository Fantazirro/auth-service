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

## Доступные эндпоинты
Список доступных эндпоинтов можно узнать с помощью инструмента Swagger  
Также список эндпоинтов доступен на [странице Wiki](https://github.com/Fantazirro/auth-service/wiki#%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%BD%D1%8B%D0%B5-%D1%8D%D0%BD%D0%B4%D0%BF%D0%BE%D0%B8%D0%BD%D1%82%D1%8B-%D0%B8-%D0%B8%D1%85-%D0%BF%D0%B0%D1%80%D0%B0%D0%BC%D0%B5%D1%82%D1%80%D1%8B)

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