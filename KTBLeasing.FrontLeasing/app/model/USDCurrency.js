Ext.define('TabUserInformation.model.USDCurrency', {
    extend: 'Ext.data.Model',
    alias: 'model.usdcurrency',

    requires: [
        'Ext.data.field.Boolean',
        'Ext.data.field.String',
        'Ext.data.field.Number'
    ],

    fields: [
        {
            type: 'boolean',
            name: 'success'
        },
        {
            type: 'string',
            name: 'source'
        },
        {
            type: 'string',
            name: 'target'
        },
        {
            type: 'float',
            name: 'rate'
        },
        {
            type: 'float',
            name: 'amount'
        },
        {
            type: 'string',
            name: 'message'
        }
    ]
});