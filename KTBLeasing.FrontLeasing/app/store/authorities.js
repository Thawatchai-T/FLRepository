/*
* File: app/store/authorizes.js
*
* This file was generated by Sencha Architect version 3.1.0.
* http://www.sencha.com/products/architect/
*
* This file requires use of the Ext JS 5.0.x library, under independent license.
* License of Sencha Architect does not include license for Ext JS 5.0.x. For more
* details see http://www.sencha.com/license or contact license@sencha.com.
*
* This file will be auto-generated each and everytime you save your project.
*
* Do NOT hand edit this file.
*/

Ext.define('TabUserInformation.store.authorizes', {
    extend: 'Ext.data.Store',
    alias: 'store.authorizes',

    requires: [
        'TabUserInformation.model.Authorize',
        'Ext.data.proxy.Rest',
        'Ext.data.reader.Json'
    ],

    config: {
        id: 'authorizes'
    },

    constructor: function (cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            storeId: 'authorizes',
            model: 'TabUserInformation.model.Authorize',
            autoLoad: true,
            pageSize: 30,
            proxy: {
                type: 'rest',
                url: 'api/user',
                reader: {
                    type: 'json'
                }
            }
        }, cfg)]);
    }
});

