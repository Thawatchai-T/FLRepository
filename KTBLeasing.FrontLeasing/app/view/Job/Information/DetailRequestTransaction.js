/*
 * File: app/view/Job/Information/DetailRequestTransaction.js
 *
 * This file was generated by Sencha Architect version 3.2.0.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 5.1.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 5.1.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('TabUserInformation.view.Job.Information.DetailRequestTransaction', {
    extend: 'Ext.window.Window',
    alias: 'widget.jobinformationdetailrequesttransaction',

    requires: [
        'TabUserInformation.view.Job.Information.DetailRequestTransactionViewModel',
        'TabUserInformation.view.Job.Information.DetailRequestTransactionViewController',
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Number',
        'Ext.toolbar.Toolbar',
        'Ext.button.Button'
    ],

    controller: 'jobinformationdetailrequesttransaction',
    viewModel: {
        type: 'jobinformationdetailrequesttransaction'
    },
    width: 750,
    bodyPadding: 10,
    title: 'New Requested Transactions Detail',
    modal: true,

    items: [
        {
            xtype: 'form',
            items: [
                {
                    xtype: 'textfield',
                    width: 200,
                    fieldLabel: '#',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Id'
                },
                {
                    xtype: 'combobox',
                    width: 500,
                    fieldLabel: 'Equipment Type',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'EquipmentType',
                    autoLoadOnValue: true,
                    displayField: 'Name',
                    store: 'CommonData.typeEquipment',
                    valueField: 'Id'
                },
                {
                    xtype: 'textfield',
                    width: 500,
                    fieldLabel: 'Equipment',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'EquipmentName'
                },
                {
                    xtype: 'numberfield',
                    fieldLabel: 'Amount (BHT)',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Amount',
                    hideTrigger: true
                },
                {
                    xtype: 'numberfield',
                    fieldLabel: 'Amount (Curr.)',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Amount',
                    hideTrigger: true
                },
                {
                    xtype: 'numberfield',
                    fieldLabel: 'Term (Months)',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Term',
                    hideTrigger: true
                },
                {
                    xtype: 'numberfield',
                    fieldLabel: 'RV % From',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'RVFrom',
                    hideTrigger: true
                },
                {
                    xtype: 'numberfield',
                    fieldLabel: 'RV % To',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'RVTo',
                    hideTrigger: true
                },
                {
                    xtype: 'numberfield',
                    fieldLabel: 'IRR %',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'IRR',
                    hideTrigger: true
                },
                {
                    xtype: 'numberfield',
                    fieldLabel: 'Final IRR %',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'FinalIRR',
                    readOnly: true,
                    hideTrigger: true
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'Insurance',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Insurance',
                    autoLoadOnValue: true,
                    displayField: 'Name',
                    store: 'CommonData.borneBy',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'Condition of Lease',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'ConditionLease',
                    autoLoadOnValue: true,
                    displayField: 'Name',
                    store: 'CommonData.conditionLease',
                    valueField: 'Id'
                },
                {
                    xtype: 'textfield',
                    width: 500,
                    fieldLabel: 'Comment',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Comment'
                },
                {
                    xtype: 'textfield',
                    fieldLabel: 'Delivery',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Delivery',
                    inputType: 'month'
                },
                {
                    xtype: 'textfield',
                    width: 500,
                    fieldLabel: 'Competitor',
                    labelAlign: 'right',
                    labelWidth: 150,
                    name: 'Competitor'
                }
            ]
        }
    ],
    dockedItems: [
        {
            xtype: 'toolbar',
            dock: 'bottom',
            ui: 'footer',
            items: [
                {
                    xtype: 'button',
                    text: 'New Indication',
                    listeners: {
                        click: 'onButtonNewIndicationClick'
                    }
                }
            ]
        }
    ]

});