# NoSQL базы данных  
## Зачем ?
NoSql базы данных отлично подходят для не структурированных данных, например записей, мы будем использовать их для хранения логов приложения.  
Логировать API аутентификации и бизнес-логики будем отдельно:  
![img.png](https://sun9-22.userapi.com/s/v1/ig2/Ew2WE5h3ep3pa_6_MwFHs9yKEr6x_Bpp6BNKdF0KOydpsjYf7ByXwvNYfsl-O7Y5tr5VaQqSxZMj-Avy1445YuIQ.jpg?size=1353x313&quality=96&type=album) 
## NuGet пакеты  
Будем исопльзовать Serilog, для этого подключим:  
![img.png](https://sun9-60.userapi.com/s/v1/ig2/OU-kgshJFpJiNZ3d2vuuZ6isNYVvRkCbAFpSR1OTLukgp9DsL74KCOcqb3Lwy-l1le-w-whWt6WJy-3GwuSdZ_dT.jpg?size=437x121&quality=96&type=album)  
## Настройка  
Настройку обозначим с помощью файла конфигурации appsettings.json:  
```json
"Serilog": {
    "MinimumLevel": {
      "Default": "Debug",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "MongoDBBson",
        "Args": {
          "databaseUrl": "mongodb://localhost:27017/VinylRecordsLogs",
          "collectionName": "Buiseness",
          "cappedMaxSizeMb": "50",
          "cappedMaxDocuments": "10000"
        }
      }
    ]
}
```
В Program.cs подключим Serilog и укажем путь к настройке.  
```cs
builder.Host.UseSerilog((context, config) => 
    config.ReadFrom.Configuration(context.Configuration));
```
Отправим запрос и запрос с ошибкой для проверки:  
![img.png](https://sun9-82.userapi.com/s/v1/ig2/h175_EQuuLC57bkEFbLG4ZY88Z8YHgkLYsm35cxtptIltVOLyc-h7HU_es8Omfh_t4LeDyBNlaNO4YYsiCTAw6mX.jpg?size=521x194&quality=96&type=album)  
![img.png](https://sun9-76.userapi.com/s/v1/ig2/CP5pRyzCSLANld2QZqr8oEyxyv3RIqC3_s-yjpuuv0Xyea8DTj3DnnRhchkJB_waKgT5c3T67BInXuxZT1CRgdmA.jpg?size=709x179&quality=96&type=album)