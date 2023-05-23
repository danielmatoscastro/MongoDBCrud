# MongoDBCrud
A simple mongo DB CRUD

## POST /users
Request:
```json
{
    "name": "Some user name"
}
```
Response:
```json
{
    "id": "14fae74c-616c-4f48-afb7-1b4f6af7f055",
    "name": "Some user name",
    "createdAt": "2018-12-10T13:45:00.000Z"
}
```

## POST /todo-lists
Request:
```json
{
    "name": "TODO List Name",
    "owner": "14fae74c-616c-4f48-afb7-1b4f6af7f055",
}
```

Response:
```json
{
    "id": "5e3fda3b-629c-4f8c-8483-95ea55a1733c",
    "name": "TODO List Name",
    "owner": "14fae74c-616c-4f48-afb7-1b4f6af7f055",
    "createdAt": "2018-12-10T13:45:00.000Z",
    "todos": []
}
```

## GET /todo-lists

Response:
```json
[
    {
        "id": "5e3fda3b-629c-4f8c-8483-95ea55a1733c",
        "name": "TODO List Name",
        "owner": "14fae74c-616c-4f48-afb7-1b4f6af7f055",
        "createdAt": "2018-12-10T13:45:00.000Z",
        "todos": []
    },
]
```

## GET /todo-lists/:id

Response:
```json
{
    "id": "5e3fda3b-629c-4f8c-8483-95ea55a1733c",
    "name": "TODO List Name",
    "owner": "14fae74c-616c-4f48-afb7-1b4f6af7f055",
    "createdAt": "2018-12-10T13:45:00.000Z",
    "todos": []
}
```