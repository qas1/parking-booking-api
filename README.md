# Parking Booking API

## Endpoints

#### [POST] /api/bookings - Create Booking

Request body:
- DateFrom
- DateTo
- Name


#### [PATCH] /api/bookings/{id} - Update Booking

Request body:
- DateFrom
- DateTo
- Name

#### [DELETE] /api/bookings/{id} - Delete Booking

#### [GET] /api/bookings/check-availability - Check Booking Availability

Returns the number of available spaces and the price for the provided dates.

Query parameters:
- DateFrom
- DateTo

## Authentication

All endpoints except `/api/bookings/check-availability` are protected. The token must be provided as a `Bearer` token in the `Authorization` header of each request.

Make a request to `[POST] /auth/token` to retrieve a fresh token. It will expire after 2 hours.


