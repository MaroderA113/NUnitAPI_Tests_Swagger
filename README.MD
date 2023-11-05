# RestAPI_Tests_Demo

## API_Tests_Demo
Демо проект тестирования одного API метода с сайта https://reqres.in/

Сервисы:
- `RestSharp_Service` с десериализацией `Newtonsoft.Json`;
- `HttpClient_Service` с десериализацией `System.Text.Json` из `String`.

Подробнее про `RestSharp` по ссылке https://restsharp.dev/intro.html

## HttpClientFactory_DI
Реализация применения IHttpClientFactory и внедрение записимостей для выполнения запроса к одному API методу с сайта https://reqres.in/

Сервисы:
- `HttpClientFactoryService_WithDefaultClient` с десериализацией `System.Text.Json` из `String`;
- `HttpClientFactoryService_WithNamedClient` с десериализацией `Newtonsoft.Json` из `String`;
- `HttpClientFactoryService_WithTypedClient` с десериализацией `Newtonsoft.Json` из `Stream`.

## DTO:
SingleUserResponse сгенерирован с помощью сервиса https://json2csharp.com/