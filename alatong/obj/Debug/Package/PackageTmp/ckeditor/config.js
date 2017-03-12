﻿/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function(config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.scayt_autoStartup = false;
    config.enterMode = CKEDITOR.ENTER_DIV;
};
CKEDITOR.on( 'instanceReady', function( ev ){
     with (ev.editor.dataProcessor.writer) {
       setRules("p",  {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("h1", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("h2", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("h3", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("h4", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("h5", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("div", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("table", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("tr", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("td", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("iframe", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("li", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("ul", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
       setRules("ol", {indent : false, breakBeforeOpen : false, breakAfterOpen : false, breakBeforeClose : false, breakAfterClose : false} );
     }
})
