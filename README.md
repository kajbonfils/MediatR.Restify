# MediatR.Restify

## This repo contains code to make it easier to use MediatR to create Rest output. 

MediatR is perfect for executing queries and commands, but the fact is that Rest by definition is queries with side effects. This is caused by the fact that even commands always return a statuscode and often also a link to a resource. And thats exactly what MediatR.Restify helps with
