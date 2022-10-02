# Alar Expense API

- [Alar Expense API](#alar-expemse-api)
  - [Create Expense](#create-expense)
    - [Create Expense Request](#create-expense-request)
    - [Create Expense Response](#create-expense-response)
  - [Get Expense](#get-expense)
    - [Get Expense Request](#get-expense-request)
    - [Get Expense Response](#get-expense-response)
  - [Update Expense](#update-expense)
    - [Update Expense Request](#update-expense-request)
    - [Update Expense Response](#update-expense-response)
  - [Delete Expense](#delete-expense)
    - [Delete Expense Request](#delete-expense-request)
    - [Delete Breakfast Response](#delete-expense-response)

## Create Expense

### Create Expense Request

```js
POST /expenses
```

```json
{
    "description": "Alexela",
    "category": "Transport",
    "amount": 40,
    "date": "2022-04-08T11:00:00",
}
```

### Create Expense Response

```js
201 Created
```

```yml
Location: {{host}}/Expenses/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "description": "Alexela",
    "category": "Transport",
    "amount": 40,
    "date": "2022-04-06T12:00:00"
}
```

## Get Expense

### Get Expense Request

```js
GET /expenses/{{id}}
```

### Get Expense Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "description": "Alexela",
    "category": "Transport",
    "amount": 40,
    "date": "2022-04-06T12:00:00"
}
```

## Update Expense

### Update Expense Request

```js
PUT /expenses/{{id}}
```

```json
{
    "description": "Alexela",
    "category": "Transport",
    "amount": 50,
    "date": "2022-04-06T12:00:00"
}
```

### Update Expense Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Expenses/{{id}}
```

## Delete Expense

### Delete Expense Request

```js
DELETE /expenses/{{id}}
```

### Delete Expenses Response

```js
204 No Content
```