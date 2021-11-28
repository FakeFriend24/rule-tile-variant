[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# RuleTile Variants

A RuleTile Variant, supporting string tags and 4 collections.

- [How to use](#how-to-use)
- [Install](#install)
  - [via Git URL](#via-git-url)

<!-- toc -->

## How to use

A pretty simple but powerful variant on Unity's RuleTile. You can define tags which will be compared to all or one out of 4 collections of tags which can be handled differently.
Supports negation as well and comes with an adjusted customEditor, which is build to handle extensions towards more than 4 collections, if you really need them.

It's probably O(n*m*l), but it does not really matter for most projects. Just keep your tags (n) and your collection lengths (m) and the number of checked collections (l = 4) in the single digits and you should be fine.   

Please keep in mind to delete empty List entries, it will be responding to them if they match. 
It also depends on 2d extras (obviously). please get that as well:

## Install

### via Git URL

Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:
```json
{
  "dependencies": {
    "com.fakefriend24.rule-tile-variant": "https://github.com/fakefriend24/rule-tile-variant.git"
  }
}
```


## License

MIT License

Copyright © 2021 FakeFriend24
