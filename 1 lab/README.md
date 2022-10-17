# Лабораторна робота №1
За умовою завдання було створено 2 сервіси та клієнт у середовищі Visual Studio та Docker Dekstop з використанням RabbitMQ, C#, REST-API, Entity Framework та Kubernetes. За бізнес логікою ми створили додаток, в якому клієнт може постити свої покупки з описом та рецензією чи варто купувати цю річ.

Перший сервіс відповідає за дані користувача та товар, про який він хоче розповісти, а другий сервіс безпосередньо за опис та заголовок даного поста.

У ролі клієнта ми використали інструмент Swagger, що допомагає нам підтримувати віртуалізацію API разом із керуванням і моніторингом. Відкрита специфікація API Swagger створює складну та автоматично згенеровану документацію та ділиться специфікацією REST API.

Також було використано RabbitMQ — це брокер повідомлень загального призначення, який підтримує протоколи, включаючи MQTT, AMQP і STOMP. Він може мати справу з випадками використання з високою пропускною здатністю, такими як обробка онлайн-платежів. У даній лабораторній роботі RabbitMq діє як брокер повідомлень між мікросервісами. При додаванні чи зміні в одному з мікросервісів інформації в бази даних, у консолі ми бачимо оновлені зміни.

Посилання на Dockerfile: <br>
https://hub.docker.com/repository/docker/fromgreensky/userservice <br>
https://hub.docker.com/repository/docker/fromgreensky/rabbitmq<br>
https://hub.docker.com/repository/docker/fromgreensky/postservice<br>

Для встановлення та запуску RabbitMq потрібно виконати дані команди в командному рядку:
docker pull rabbitmq:3-management

docker run --rm -it --hostname my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management

Тепер зайшовши на http://localhost:15672 , використовуючи ім’я користувача «guest» і пароль «guest», ми створили Exchange з іменем «user» типу «Fanout» і двома чергами «user.postservice» і «user.otherservice».

<img width="684" alt="image" src="https://user-images.githubusercontent.com/71703420/195991493-c5ad3144-9306-446f-ab5f-fed0d4f46332.png">

Тепер запустивши Debug з Multiple Startup Projects можемо бачити 2 сервіси:

<img width="776" alt="image" src="https://user-images.githubusercontent.com/71703420/195992044-28f96d48-2274-4f9c-a3e5-04e2139358a1.png">

<img width="733" alt="image" src="https://user-images.githubusercontent.com/71703420/195992631-3a086ae7-2691-42f2-878a-4228da2a76d4.png">

Додамо в обох сервісах нового користувача та опис товару.

<img width="250" alt="image" src="https://user-images.githubusercontent.com/71703420/195992226-6e7c02e3-bf31-4fc8-98c3-29a8ae7ef035.png">

<img width="270"  alt="image" src="https://user-images.githubusercontent.com/71703420/195992831-4570fc69-326b-4c2c-ab08-5010b1e92f87.png">

Можемо бачити успішне виконнаня:

<img width="270" heigth = "150" alt="image" src="https://user-images.githubusercontent.com/71703420/196036425-a39cc101-3bd8-4feb-8471-fe904fa51608.png">

Хід виконання роботи: 

Створимо образ Docker для кожного додатку. Можемо переглянути поточні образи, помітимо, що також є образ rabbitmq: 

<img width="738" alt="image" src="https://github.com/annsperkach/Microservices-14team/blob/master/1%20lab/Screenshots/image.png">

Розгорнемо Deployment для UserService: 

<img width="738" alt="image" src="https://github.com/annsperkach/Microservices-14team/blob/master/1%20lab/Screenshots/deploy.png">

Створимо Service для UserService:

<img width="738" alt="image" src="https://github.com/annsperkach/Microservices-14team/blob/master/1%20lab/Screenshots/service.png">

Аналогічно і для PostService:

<img width="738" alt="image" src="https://github.com/annsperkach/Microservices-14team/blob/master/1%20lab/Screenshots/deploy%2Bservice2.png">

Сервіси успішно створені: 

<img width="738" alt="image" src="https://github.com/annsperkach/Microservices-14team/blob/master/1%20lab/Screenshots/getservices.png">

Використаємо Ingress:

<img width="738" alt="image" src="https://github.com/annsperkach/Microservices-14team/blob/master/1%20lab/Screenshots/ingress.png">










