# RestAPI_Tests_Demo

## API_Tests_Demo
Демо проект тестирования одного API метода с сайта https://reqres.in/

Интерфейсы:
- `IRestService`;
- `IRefitService`;
- `IMockService`.

Сервисы:
- `HttpClient_Service`;
- `HttpClientFactory_Service`;
- `RestSharp_Service`.

Тесты:
- `HttpClient_Tests` с десериализацией `System.Text.Json` из `String`;
- `HttpClientFactory_Tests` с десериализацией `System.Text.Json` из `String`;
- `Refit_Tests` с десериализацией `Newtonsoft.Json`;
- `RestSharp_Tests` с десериализацией `Newtonsoft.Json`;
- `Mock_Tests`.

Подробнее про `RestSharp` по ссылке https://restsharp.dev/intro.html

## HttpClientFactory_DI
Реализация применения IHttpClientFactory и внедрение зависимостей для выполнения запроса к одному API методу с сайта https://reqres.in/

Для использования соответствующего сервиса нужно раскомментировать соотвествующие строки в классе `Program`.

Сервисы:
- `HttpClientFactoryService_DefaultClient`;
- `HttpClientFactoryService_NamedClient`;
- `HttpClientFactoryService_TypedClient`.

Тесты:
- `DefaultClient_Tests` с десериализацией `System.Text.Json` из `String`;
- `NamedClient_Tests` с десериализацией `Newtonsoft.Json` из `String`;
- `TypedClient_Tests` с десериализацией `Newtonsoft.Json` из `Stream`.

## DTO:
SingleUserResponse сгенерирован с помощью сервиса https://json2csharp.com/