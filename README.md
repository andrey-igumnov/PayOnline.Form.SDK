## PayOnline.Form.SDK
Simple payment URL generator for PayOnline IPSP

## Description

## Usage
### PaymentUri
PayOnline form payment URL could be initialized in PaymentUri constructor
```cs
public PaymentUri(
    Uri processingUri,
    MerchantSettings merchantSettings,
    OrderInfo orderInfo,
    PaymentMethod paymentMethod = PaymentMethod.Card,
    Language language = Language.Russian,
    RedirectParameters redirectParameters = null,
    NameValueCollection customData = null)
```
#### Parameters
Parameter | Type | Description | Default value
--- | --- | --- | ---
processingUri | System.Uri | Base processing URL | 
merchantSettings | PayOnline.Form.SDK.MerchantSettings | Merchant settings | 
orderInfo | PayOnline.Form.SDK.OrderInfo | Order information | 
paymentMethod | PayOnline.Form.SDK.PaymentMethod | Payment method | Card
language | PayOnline.Form.SDK.Language | Payment form language | Russian
redirectParameters | PayOnline.Form.SDK.RedirectParameters | Regirect parameters, such ad Return or Success URL | null
customData | System.Collections.Specialized.NameValueCollection | Any custom data, These parameters will be included in the callback query string | null

### MerchantSettings
Represents merchant settings
```cs
public MerchantSettings(
    int merchantId,
    string key)
```
#### Parameters
Parameter | Type | Description | Default value
--- | --- | --- | ---
merchantId | System.Int32 | Identification code, assigned by PayOnline | 
key | System.String | PrivateSecurityKey, assigned by PayOnline | 

### OrderInfo
Represents order information
```cs
public OrderInfo(
    string orderId,
    decimal amount,
    string currency,
    string orderDescription = null,
    DateTime? validUntil = null)
```
#### Parameters
Parameter | Type | Description | Default value
--- | --- | --- | ---
orderId | System.String | Identification code of the order in the merchant system | 
amount | System.Decimal | Total amount of the order | 
currency | System.String | Currency of the order in ISO 4217 format (e.g. USD, EUR) | 
orderDescription | System.String | Comment to the order, which will be displayed to the payer under order number on payment forms and in the notification on e-mail | null
validUntil | System.DateTime | Period “pay before”, time zone UTC (GMT+0) | null

### PaymentMethod
Represents default payment form layout
```cs
public enum PaymentMethod
```
#### Members
Member name | Value | Description
--- | --- | --- | ---
Card | 0 | Payment by bank card
Qiwi | 1 | Payment by QIWI wallet
PayMaster | 2 | Payment by WebMoney (PayMaster)
YandexMoney | 3 | Payment by Yandex.Money wallet
Select | 4 | Form of choosing payment method links to all possible payment methods

### Language
Represents payment form language
```cs
public enum Language
```
#### Members
Member name | Value | Description
--- | --- | --- | ---
Russian | 0 | Russian payment form
English | 1 | English payment form

### RedirectParameters
Represents after payment process redirect parameters
```cs
public RedirectParameters(
    Uri returnUrl = null,
    Uri failUrl = null)
```
#### Parameters
Parameter | Type | Description | Default value
--- | --- | --- | ---
returnUrl | System.Uri | Absolute URL address that will be sent to the payer after completion of payment | null
failUrl | System.Uri | Absolute URL address that will be sent to the payer, in case it is impossible to make a payment | null


## Contributing

* Fork it
* Clone it git clone https://github.com/andrey-igumnov/PayOnline.Form.SDK
* Create your feature branch git checkout -b my-new-feature
* Commit your changes git commit -am 'Add some feature'
* Push to the branch git push origin my-new-feature
* Create new pull request through Github

## License
Licensed under the MIT License. See LICENSE file in the project root for full license information.
