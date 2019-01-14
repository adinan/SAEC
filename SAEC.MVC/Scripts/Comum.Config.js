function ConfigurarEntrada() {

    $("#Telefone").inputmask("(99)9999-9999");
    $("#Celular").inputmask("(99)99999-9999");
    $("#CEP").inputmask("99.999-999");
    $("#Cpf").inputmask("999.999.999-99");
    

    $("#Cpf").focusout(function () {
        var cpf = $(this).val();

        cpf = cpf.replace(/\./g, "");
        cpf = cpf.replace(/\-/g, "");
        cpf = cpf.replace(/\_/g, "");
        cpf = $.trim(cpf.toString());
        cpf = cpf + "";

        var numeros, digitos, soma, i, resultado, digitosIguais;
        digitosIguais = 1;
        if (cpf.length < 11) {
            $(this).addClass("ui-state-error");
        } else {
            $(this).removeClass("ui-state-error");
        }
        for (i = 0; i < cpf.length - 1; i++)
            if (cpf.charAt(i) !== cpf.charAt(i + 1)) {
                digitosIguais = 0;
                break;
            }
        if (!digitosIguais) {
            numeros = cpf.substring(0, 9);
            digitos = cpf.substring(9);
            soma = 0;
            for (i = 10; i > 1; i--)
                soma += numeros.charAt(10 - i) * i;
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado !== digitos.charAt(0)) {
                $(this).addClass("ui-state-error");
            } else {
                $(this).removeClass("ui-state-error");
            }

            numeros = cpf.substring(0, 10);
            soma = 0;
            for (i = 11; i > 1; i--)
                soma += numeros.charAt(11 - i) * i;
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado !== digitos.charAt(1)) {
                $(this).addClass("ui-state-error");
            } else {
                $(this).removeClass("ui-state-error");
            }
        }
    });

    $(".CheckMoney").keydown(function (event) {
        var i, exceptions = [8, 46, 37, 39, 13, 9, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105];

        var qtdeCaracter = $(this).val().length;
        var posVirgula = $(this).val().indexOf(",", 0);

        if (posVirgula > 0 && (posVirgula) === qtdeCaracter - 3) {
            event.returnValue = false;
            return;
        }

        if ($(this).val().indexOf(",", 0) < 0) {
            exceptions.push(110);
            exceptions.push(188);
        }

        // backspace, delete, arrowleft & right, enter, tab
        var isException = false;
        var k = String.fromCharCode(event.keyCode);

        for (i = 0; i < exceptions.length; i++)
            if (exceptions[i] === event.keyCode)
                isException = true;
        if (isNaN(k) && (!isException))
            event.returnValue = false;
        else {
            var p = new String(currency.value + k).indexOf(".");
            if ((p < currency.value.length - 2) && p > -1 && (!isException))
                event.returnValue = false;
            else if (currency.value.length >= 15 && (!isException))
                event.returnValue = false;
        }
        if (event.returnValue === false)
            event.preventDefault();
    });

    $(".CheckDecimal").keydown(function (event) {
        var i, exceptions = [8, 46, 37, 39, 13, 9, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105];
        if ($(this).val().indexOf(",", 0) < 0) {
            exceptions.push(110);
            exceptions.push(188);
        }

        // backspace, delete, arrowleft & right, enter, tab
        var isException = false;
        var k = String.fromCharCode(event.keyCode);

        for (i = 0; i < exceptions.length; i++)
            if (exceptions[i] === event.keyCode)
                isException = true;
        if (isNaN(k) && (!isException))
            event.returnValue = false;
        else {
            var p = new String(currency.value + k).indexOf(".");
            if ((p < currency.value.length - 2) && p > -1 && (!isException))
                event.returnValue = false;
            else if (currency.value.length >= 15 && (!isException))
                event.returnValue = false;
        }
        if (event.returnValue === false)
            event.preventDefault();
    });

    $(".CheckInteger").keydown(function (event) {

        var i, exceptions = [8, 46, 37, 39, 13, 9, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105];

        // backspace, delete, arrowleft & right, enter, tab
        var isException = false;
        var isDot = (188 === event.keyCode); // dot
        var k = String.fromCharCode(event.keyCode);

        for (i = 0; i < exceptions.length; i++)
            if (exceptions[i] === event.keyCode)
                isException = true;
        if (isNaN(k) && (!isException) && (!isDot))
            event.returnValue = false;

        if (event.returnValue === false)
            event.preventDefault();
    });

    //$.datepicker.setDefaults($.datepicker.regional["pt-BR"]);
    //$(".DatePicker").mask("99/99/9999");
    //$(".DatePicker").datepicker({
    //    closeText: "Fechar",
    //    prevText: "&#x3c;Anterior",
    //    nextText: "Pr&oacute;ximo&#x3e;",
    //    currentText: "Hoje",
    //    monthNames: [
    //        "Janeiro", "Fevereiro", "Mar&ccedil;o", "Abril", "Maio", "Junho",
    //        "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
    //    ],
    //    monthNamesShort: [
    //        "Jan", "Fev", "Mar", "Abr", "Mai", "Jun",
    //        "Jul", "Ago", "Set", "Out", "Nov", "Dez"
    //    ],
    //    dayNames: [
    //        "Domingo", "Segunda-feira", "Ter&ccedil;a-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira",
    //        "S&aacute;bado"
    //    ],
    //    dayNamesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "S&aacute;b"],
    //    dayNamesMin: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "S&aacute;b"],
    //    weekHeader: "Sm",
    //    dateFormat: "dd/mm/yy",
    //    firstDay: 0,
    //    isRTL: false,
    //    showMonthAfterYear: false,
    //    yearSuffix: ""
    //});

    //$(".TimePicker").mask("99:99");
    //$(".TimePicker").timepicker({
    //    timeOnlyTitle: "Selecione hora",
    //    timeText: "Hora",
    //    hourText: "Hora",
    //    minuteText: "Minuto",
    //    secondText: "Segundo",
    //    currentText: "Agora",
    //    closeText: "Fechar",
    //    clearText: "Limpar",
    //    stepMinute: 5
    //});

    //$(".DateTimePicker").datetimepicker({
    //    timeOnlyTitle: "Selecione hora",
    //    timeText: "Hora",
    //    hourText: "Hora",
    //    minuteText: "Minuto",
    //    secondText: "Segundo",
    //    currentText: "Agora",
    //    clearText: "Limpar",
    //    stepMinute: 5,
    //    closeText: "Fechar",
    //    prevText: "&#x3c;Anterior",
    //    nextText: "Pr&oacute;ximo&#x3e;",
    //    monthNames: [
    //        "Janeiro", "Fevereiro", "Mar&ccedil;o", "Abril", "Maio", "Junho",
    //        "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
    //    ],
    //    monthNamesShort: [
    //        "Jan", "Fev", "Mar", "Abr", "Mai", "Jun",
    //        "Jul", "Ago", "Set", "Out", "Nov", "Dez"
    //    ],
    //    dayNames: [
    //        "Domingo", "Segunda-feira", "Ter&ccedil;a-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira",
    //        "S&aacute;bado"
    //    ],
    //    dayNamesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "S&aacute;b"],
    //    dayNamesMin: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "S&aacute;b"],
    //    weekHeader: "Sm",
    //    dateFormat: "dd/mm/yy",
    //    firstDay: 0,
    //    isRTL: false,
    //    showMonthAfterYear: false,
    //    yearSuffix: ""
    //});

}
