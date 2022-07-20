# Orchard Core Commerce

[![Join the chat at https://gitter.im/OrchardCore-Commerce/Lobby](https://badges.gitter.im/OrchardCore-Commerce/Lobby.svg)](https://gitter.im/OrchardCore-Commerce/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

The commerce module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore).

## History, status, and planning

Orchard Core Commerce will be an Orchard Core port and partial rewrite of the open source [Nwazet Commerce](https://github.com/bleroy/Nwazet.Commerce) module that was built for Orchard CMS 1.x. Nwazet Commerce was initially built in 2012 by [Bertrand Le Roy](https://github.com/bleroy), loosely based on [a commerce sample](http://www.ideliverable.com/blog/writing-an-orchard-webshop-module-from-scratch-part-1) by [Sipke Shoorstra](https://github.com/sfmskywalker). The initial goal of Nwazet Commerce was to power the web site of the hardware startup Nwazet. While Nwazet is no longer operating, the Nwazet Commerce project went on, and was further developed by a group of passionate contributors who are using the platform for their own, and their customer's web sites.

Like Orchard, Nwazet Commerce was built with extensibility in mind, and as such it has its own extensions (typical examples include local tax and shipping modules). It's also pure, idiomatic Orchard.

Orchard Core represents a major evolution of the Orchard design principles, and is sufficiently different that running Nwazet Commerce on it will necessitate significant work. As such, we've decided that starting from a blank slate was the best way to go, so we'll port Nwazet Commerce piece by piece, being careful to accurately apply Orchard Core's new design principles. We also decided to adopt a new name, that gets rid of the now obsolete origins, and establishes our ambition for the module to become the go-to commerce module for Orchard Core.

This work is in its initial design phases. There's a lot of work to do, and yes, we do welcome participation in any shape or form.

The work will focus at first on porting a [minimum viable feature set](https://github.com/OrchardCMS/OrchardCore.Commerce/issues/3).

### Done:

* Product, price, and inventory parts and/or fields (those were a single part in Nwazet)
  Note: not all products have a price
* Shopping cart
* Base infrastructure for payment, plus one implementation (Stripe)

### To do:
* Checkout (probably redesigned around Orchard Workflows)
* Order content type and management screens (including a redesign and refactoring of the order part)
* Workflow activities

Globalization should be taken into account at every step.

## Setting up your dev environment

1. Clone this repository.
2. Build and run the `SampleWebApp` project.
3. From the admin, enable the module's only feature.
4. (optional) Start using the features, by creating a new `Product` content type, and adding the product part to it.

## Test data for Stripe Payment

### API keys

Stripe API uses a secret-publishable key pair. The following API keys are public sample test keys, they can be found in [Stripe's documentation](https://stripe.com/docs/keys#obtain-api-keys).

* Publishable key: `pk_test_51H59owJmQoVhz82aWAoi9M5s8PC6sSAqFI7KfAD2NRKun5riDIOM0dvu2caM25a5f5JbYLMc5Umxw8Dl7dBIDNwM00yVbSX8uS`
* Secret key: `sk_test_51H59owJmQoVhz82aOUNOuCVbK0u1zjyRFKkFp9EfrqzWaUWqQni3oSxljsdTIu2YZ9XvlbeGjZRU7B7ye2EjJQE000Dm2DtMWD`

**These are just test keys. Don’t submit any personally identifiable information in requests made with this key.**

The Stripe API key pair can be set inside *Dashboard → Settings → Stripe API*.

### Cards
There are available test cards that can be found in [Stripe's documentation](https://stripe.com/docs/testing).

There are multiple test cards that can simulate any scenario, including error codes. Here are two examples:

| Brand | Number	 | CVC | Date | Result |
| --------------- | --------------- | --------------- | --------------- |--------------- |
| Visa | 4242424242424242 | Any 3 digits | Any future date | Success |
| - | 4000000000009995 | Any 3 digits | Any future date | card_declined,	insufficient_funds |

## Demo video

[![Watch the video](https://img.youtube.com/vi/EVvwS1UaIk4/maxresdefault.jpg)](https://youtu.be/EVvwS1UaIk4)