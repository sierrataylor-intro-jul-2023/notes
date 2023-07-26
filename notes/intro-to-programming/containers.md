Kernel- the "inner ring" part of Linux that that has access to the processor, memory, hardware,
	- Microsoft ships a Linux Kernel on the Windows subsystem for Linux; this enables the Windows system to run Linux
cluster- a group of computers you treat as one
	- clusters are driven by applications which access the cluster through authentication and authorization
		- example: sending a GET request from our todo application will send the GET to the cluster
		- clusters drive databases
- distributed application- multiple services distributed throughout the cluster
- service-oriented architecture
	- API gateway catalog
	- heavily reliant on RPCs
**containers solve 2 big problems** 
- dev/prod parity- running the software on 2 very different machines (e.g. "I don't know what's wrong, it works on my machine")
- sharing a server- traffic, avoid using up resources
	- resources: CPU, memory, Storage (disk)
	- "singleton" issues- disk paths (c:\temp), networking (TCP ports)
Docker
- when using docker, you must create a `docker-compose.yml` file to establish the standard for a multi-container application
```YAML
services:

  db:

    image: postgres:15.2-bullseye

    environment:

      POSTGRES_PASSWORD: password

      POSTGRES_USER: user

    ports:

      - 5432:5432

    volumes:

      - db_data:var/lib/postgresql/data

      - ./db/:/docker-entrypoint-initdb.d/

  

volumes:

  db_data:
```

- 