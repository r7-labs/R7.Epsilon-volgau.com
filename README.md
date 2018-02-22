# About R7.Epsilon.Customizations

The *R7.Epsilon.Customizations* package provide various customization resources for *R7.Epsilon* skin used by volgau.com portals.
You can use it just as an example of various *R7.Epsilon* customization options -
or you can fork it to make customization package for your own website.

## Install & upgrade

1. Install *R7.Epsilon* skin package.
2. Install *R7.Epsilon.Customizations* package.

## Uninstall

The *R7.Epsilon.Customizations* is listed under *Modules* section in *Host &gt; Extensions*.

1. Uninstall *R7.Epsilon.Customizations* package.
2. Re-install *R7.Epsilon* skin package.

## License

[![AGPLv3](https://www.gnu.org/graphics/agplv3-155x51.png)](https://www.gnu.org/licenses/agpl-3.0.html)

The *R7.Epsilon.Customizations* is free software: you can redistribute it and/or modify it under the terms of 
the GNU Affero General Public License as published by the Free Software Foundation, either version 3 of the License, 
or (at your option) any later version.

## Customization

This section should be part of *R7.Epsilon* wiki.

### Portal-level config

The hard way to start with DNN skin customization is to fork a skin repository and then make changes in a fork.
But there are other ways, as unlike many other DNN skins, *R7.Epsilon* is developed in customization in mind.

Below I'll try to explain available customization options and "extension points".

You can set portal-level configuration options via editing `R7.Epsilon.yml` file located in the portal root directory.

Portal config file is YAML file. Most important ones described in the table:

Setting Name  | Default value            | Description
------------- | ------------------------ | -------------
skin-css      | css/default-skin.min.css | Path to main CSS file (relative to the `Skins` folder)
skin-a11y-css | css/a11y-skin.min.css    | Path to accesibility version of CSS file (relative to the `Skins` folder)
menu-url-type | 0                        | Type of URLs used in menus. 0 - default (friendly) URLs, 1 - `/Default.aspx?TabId=xxx` URLs, 2 - `/TabId/xxx` URLs

### Control redirect type for short menu URLs

If you choose to use short menu URLs of type 2, in some cases  it would be useful 
to adjust *Host &gt; Advanced &gt; Friendly URL Settings* rule for `[^?]*/TabId?(\d+)(.*)`
by replacing `~/Default.aspx?TabID=$1` with `~/LinkClick.aspx?link=$1`.

Note that the `Default.aspx` rule will produce 301 redirects - which is faster, but may cause problems with browser history if page URL changes.
And the `LinkClick.aspx` rule will produce 302 redirects - which is slower, but more reliable in case of page URL changes.
