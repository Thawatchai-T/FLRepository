/*
 * File: app/store/stampDuties.js
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

Ext.define('TabUserInformation.store.stampDuties', {
    extend: 'Ext.data.Store',
    alias: 'store.stampduties',

    requires: [
        'TabUserInformation.model.StampDuty',
        'Ext.data.proxy.Memory'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            storeId: 'stampDuties',
            model: 'TabUserInformation.model.StampDuty',
            data: [
                {
                    Id: 566,
                    CustomerCode: 'et',
                    BorneBy: 409,
                    Amount: 475.54
                },
                {
                    Id: 309,
                    CustomerCode: 'repellendus',
                    BorneBy: 76,
                    Amount: 312.81
                },
                {
                    Id: 587,
                    CustomerCode: 'neque',
                    BorneBy: 314,
                    Amount: 449.11
                }
            ],
            proxy: {
                type: 'memory'
            }
        }, cfg)]);
    }
});