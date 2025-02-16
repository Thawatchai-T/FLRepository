/*
 * File: app/view/Home/indexViewModel.js
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

Ext.define('TabUserInformation.view.Home.indexViewModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.homeindex',
    requires: [
        'TabUserInformation.model.RoleInTabs',
        'Ext.data.proxy.Rest'
    ],

    stores: {
        userinfoStore: {
            model: 'TabUserInformation.model.RoleInTabs',
            //fields: ['UserId', 'RoleName'],
            proxy: {
                type: 'rest',
                
                url: 'api/login/GetLogingProperties'
            },
            reader: {
                type: 'json',
                rootProperty: 'data',
            }
        }
    }

});