/*
 * File: app/view/Job/Application/Tab/PurchaseOrderViewModel.js
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

Ext.define('TabUserInformation.view.Job.Application.Tab.PurchaseOrderViewModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.jobapplicationtabpurchaseorder',

    requires: [
        'Ext.data.Store',
        'Ext.data.proxy.Rest',
        'Ext.data.reader.Json'
    ],

    stores: {
        purchaseOrders: {
            model: 'TabUserInformation.model.PurchaseOrder',
            autoLoad: true,
            proxy: {
                type: 'rest',
                url: 'api/PurchaseOrder',
                reader: {
                    type: 'json'
                },
                writer: {
                    type: 'json',
                    writeAllFields: true
                },
                api: {
                    create: 'api/PurchaseOrder/Post',
                    read: 'api/ApplicationDetail'
                }
            },
            sorters: [{
                property: 'Id',
                direction: 'ASC'
            }],
            listeners: {
                beforeload: 'onStoreBeforeLoad'
            }
        }
    }

});