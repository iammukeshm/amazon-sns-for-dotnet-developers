# Publishing to Amazon SNS via ASP.NET Core WebAPI: Serverless Notification Service

Amazon SNS is an excellent choice if you’re looking to build a scalable, real-time notification system. In this article, we will learn about Amazon SNS and how to create Topics and publish messages on this topic from an ASP.NET Core application using the Amazon C# SDKs. We will add subscribers to this SNS Topics for the Email and AWS Lambda Protocols. This way, whenever our ASP.NET Core application emits a new notification to the SNS Topic, the subscriber will receive an Email and trigger an AWS Lambda. These concepts are pretty vital for building Distributed systems and Microservices. We will also look into the SNS behavior when there is a delivery failure and dead letter queues.

![Amazon SNS for .NET Developers](https://codewithmukesh.com/wp-content/uploads/2023/05/Amazon-SNS-for-.NET-Developers.png)

Here are the covered topics:

- 👉What is Amazon SNS, or Simple Notification Service?
- 👉Amazon SNS vs SQS
- 👉PubSub Architecture with Amazon SNS
- 👉Creating an Amazon SNS Topic via .NET
- 👉Publishing the Message to the SNS Topic via .NET
- 👉Email Subscription
- 👉Lambda Subscription
- 👉Amazon SNS Filter Policy
- 👉Retries & Dead Letter Queues



Read the article: https://codewithmukesh.com/blog/scalable-notifications-with-amazon-sns-and-aspnet-core/
