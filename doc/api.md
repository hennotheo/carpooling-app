## CarPooling API Documentation

Decris toutes les requetes possibles pour l'API

### Users [/User]
#### Create a User [POST]
**[POST]** `api/User`
- Response 201 (application/json)
- Body (WIP)
```json
{
  WIP
}
```

#### Get a User [GET]
**[GET]** `api/User/{id}`
- Response 200 (application/json)
```json
{
  WIP
}
```

#### Delete a User [DELETE]
**[DELETE]** `api/User/{id}`
- Response 200 (application/json)

#### Search Users [GET]
**[GET]** `api/User/Search`
- Response 200 (application/json)
- Query Params :
  - 'max' : maximum number of users to return (default = 25)
```json
[
  {
    //USER 1 CONTENT
  },
  {
    //USER 2 CONTENT 
  }
]
```