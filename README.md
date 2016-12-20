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


## Contributing

* Fork it
* Clone it git clone https://github.com/andrey-igumnov/PayOnline.Form.SDK
* Create your feature branch git checkout -b my-new-feature
* Commit your changes git commit -am 'Add some feature'
* Push to the branch git push origin my-new-feature
* Create new pull request through Github

## License
Licensed under the MIT License. See LICENSE file in the project root for full license information.
