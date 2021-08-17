var ModalMessageDefault = {
    //Agregar todos los Titulos en esta Sección
    TITLE_WARNING: "¡ Advertencia !",
    TITLE_DELETE: "Eliminar",
    TITLE_CHANGE_STATE: "Activar/Desactivar",

    //Agregar todos los mensajes
    MESSAGE_DELETE: "¿ Seguro que desea eliminar el registro seleccionado ?",
    MESSAGE_DELETE_LIST: "¿ Seguro que desea eliminar el listado ?",
    MESSAGE_DELETE_MULTIPLE_ROW: "¿ Seguro que desea eliminar los registros seleccionados ?",
    MESSAGE_CHANGE_STATE: "¿ Seguro que desea modificar el estado del registro seleccionado ?",    
    MESSAGE_CHANGE_STATE_MULTIPLE_ROW: "¿ Seguro que desea modificar el estado de los registros seleccionados ?"
}


ToastMessage = {
    TITLE_WARNING: "¡ Advertencia !",
    SELECT_ROW: "Por favor, seleccione un registro",
    SELECT_EMPLOYEE: "Por favor, seleccione un empleado",
    getTitleCreate: function (title) {
        return `Crear ${title}`;
    },
    getTitleEdit: function (title) {
        return `Modificar ${title}`;
    },
    getTitleChangeState: function (title) {
        return `Activar/Desactivar ${title}`;
    },
    getTitleDelete: function (title) {
        return `Eliminar ${title}`;
    },
}

var TooltipsMessage = {
    TITLE_SAVE: "Presione para guardar los datos",
    TITLE_EDIT: "Presione para guardar los datos editados",
    TITLE_PRINT: "Presione para imprimir",
    TITLE_DELETE: "Presione para eliminar"
}
