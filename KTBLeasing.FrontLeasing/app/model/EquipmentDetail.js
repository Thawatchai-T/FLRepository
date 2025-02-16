/*
 * File: app/model/EquipmentDetail.js
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

Ext.define('TabUserInformation.model.EquipmentDetail', {
    extend: 'Ext.data.Model',
    alias: 'model.equipmentdetail',

    requires: [
        'Ext.data.field.Integer',
        'Ext.data.field.Date',
        'Ext.data.field.Boolean'
    ],

    idProperty: 'Id',

    fields: [
        {
            type: 'int',
            name: 'Id'
        },
        {
            type: 'int',
            name: 'EquipmentListId'
        },
        {
            type: 'int',
            name: 'SubType'
        },
        {
            type: 'int',
            name: 'Brand'
        },
        {
            name: 'Model'
        },
        {
            name: 'CC'
        },
        {
            name: 'SerialNo'
        },
        {
            name: 'FrameChassisSerialNo'
        },
        {
            name: 'FLNo'
        },
        {
            type: 'date',
            name: 'DateInvoice',
            dateWriteFormat: 'MS'
        },
        {
            type: 'date',
            name: 'DueDate',
            dateWriteFormat: 'MS'
        },
        {
            name: 'ChassisNo'
        },
        {
            name: 'EngineNo'
        },
        {
            name: 'Color'
        },
        {
            name: 'LicenseNo'
        },
        {
            type: 'int',
            name: 'PriceCar'
        },
        {
            type: 'boolean',
            name: 'Book'
        },
        {
            type: 'int',
            name: 'BookBy'
        },
        {
            type: 'date',
            name: 'BookReceivedDate',
            dateWriteFormat: 'MS'
        },
        {
            type: 'date',
            name: 'BookReturnDate',
            dateWriteFormat: 'MS'
        },
        {
            name: 'PowNo'
        },
        {
            type: 'boolean',
            name: 'SpareKey'
        },
        {
            type: 'int',
            name: 'SpareBy'
        },
        {
            type: 'date',
            name: 'SpareReceivedDate',
            dateWriteFormat: 'MS'
        },
        {
            type: 'date',
            name: 'SpareReturnDate',
            dateWriteFormat: 'MS'
        },
        {
            name: 'Remark'
        }
    ]
});