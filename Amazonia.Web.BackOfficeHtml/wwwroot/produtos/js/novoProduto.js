$(document).ready(function () {

    $('#btnSubmit').click(function () {
        console.log("click button ajax");

        $.ajax({
            type: "POST",
            url: "https://localhost:44392/api/Livro",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify({
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "XXXXXX",
            "autor": "string",
            "formato": "string",
            "idioma": "string",
            "quantidadeEmEstoque": 0,
            "descricao": "string",
            "tipoLivro": 0
                })
            });
    });

});
