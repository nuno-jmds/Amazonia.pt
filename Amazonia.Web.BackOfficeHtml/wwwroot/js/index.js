function AtualizarValoresPaineis() {
    $("#lblNumeroVendas").text("0");
    $("#lblNumeroVendasCanceladas").text("0");
    $("#lblClientesNovos").text("0");
    $("#lblLivrosAesgotar").text("0"); 
}


var valor=fetch("https://api.blockcypher.com/v1/btc/main", {
    method: 'GET'
}).then((response) => {
        console.log('block Success: status', response.status);
        return response.json();
}).then((data) => {
    $("#lblNumeroVendasCanceladas").text(data.height);
        console.log('block Data: ', data.height);
}).catch((error) => {
    console.error('Error:', error);
    $("#lblNumeroVendasCanceladas").text("Nok");
});;

var valor = fetch("https://localhost:44392/api/Vendas", {
    method: 'GET'
}).then((response) => {
    console.log('vendas Success: status', response.status);
    return response.json();
}).then((data) => {
    $("#lblNumeroVendas").text(data.quantidade);
    console.log('vendas Data: ', data.quantidade);
}).catch((error) => {
    console.error('Error:', error);
    $("#lblNumeroVendas").text("Nok");
});;



    $.ajax({
            url: "https://localhost:44392/api/Vendas",
            type: "GET",
        }).done(function (responseText) {
            console.log("ajax Success: status",responseText);
            $("#lblClientesNovos").text(responseText.quantidade);
        }).fail(function (responseText) {
            console.error(responseText);
            $("#lblClientesNovos").text("NOK");
        });



 


function AtualizarGraficoVendas() {
    $('#imgGraficoVendas').text('grafico de vendas');
    google.charts.load("current", { packages: ['corechart'] });
    google.charts.setOnLoadCallback(CarregarDadosDoGrafico);
    function CarregarDadosDoGrafico() {
        var data = google.visualization.arrayToDataTable([
            ["Dia", "Vendas concretizadas", "Vendas Canceladas"],
            ["Domingo", Math.floor(Math.random() * 100), Math.floor(Math.random() * 100)],
            ["segunda", Math.floor(Math.random() * 100), Math.floor(Math.random() * 100)],
            ["terça", Math.floor(Math.random() * 100), Math.floor(Math.random() * 100)],
            ["quarta", Math.floor(Math.random() * 100), Math.floor(Math.random() * 100)],
            ["quinta", Math.floor(Math.random() * 100), Math.floor(Math.random() * 100)],
            ["sexta", Math.floor(Math.random() * 100), Math.floor(Math.random() * 100)],
            ["sábado", Math.floor(Math.random() * 100), Math.floor(Math.random() * 100)]
        ]);

        var view = new google.visualization.DataView(data);
        view.setColumns([0, 1,
            {
                calc: "stringify",
                sourceColumn: 1,
                type: "string",
                role: "annotation"
            }, 2,
            {
                calc: "stringify",
                sourceColumn: 2,
                type: "string",
                role: "annotation"
            }
        ]);

        var options = {
            curveType: 'function',
            legend: { position: 'bottom' }
        };

        var chart = new google.visualization.LineChart(document.getElementById('imgGraficoVendas'));
        chart.draw(data, options);

    }
}

function AtualizarGraficoClientes() {
    $('#imgGraficoClientesNovos').text('grafico de vendas');
    google.charts.load('current', { packages: ['corechart','bar'] });
    google.charts.setOnLoadCallback(CarregarDadosDoGrafico);

    function CarregarDadosDoGrafico() {

        //Carregar a partir da webapi
        var data = google.visualization.arrayToDataTable([
            ['Dia', ''],
            ['Domingo', 512],
            ['Segunda', 1170],
            ['Terça', 21],
            ['Quarta', 100],
            ['Quinta', 354],
            ['Sexta', 100],
            ['Sábado', 660],
        ]);


        var options = {
            curveType: 'function',
            legend: { position: 'none' }
        };

        var chart = new google.charts.Bar(document.getElementById('imgClientesNovos'));
        chart.draw(data, options);
    }

}

function AtualizarGraficoEstoques() {
    $('#imgGraficoEstoqueLivros').text('grafico de vendas');
    google.charts.load('current', { packages: ['corechart'] });
    google.charts.setOnLoadCallback(CarregarDadosDoGrafico);

    function CarregarDadosDoGrafico() {
        var data = google.visualization.arrayToDataTable([
            ['Livro', 'Quantidade Disponível'],
            ['Harry Potter', 101],
            ['O Senhor do Anéis', 20],
            ['As Crônicas de Gelo e Fogo', 57],
            ['Eragon', 28],
            ['As Crônicas de Nárnia', 70]
        ]);


        var options = {
            legend: { position: 'bottom' }
        };
        var chart = new google.visualization.PieChart(document.getElementById('imgEstoqueLivros'));

        chart.draw(data, options);
    }
}


$(document).ready(function () {
    var menu = document.getElementById("navHome");
    AtivarMenuNavegacao(menu);
    AtualizarValoresPaineis();
    AtualizarGraficoClientes();
    AtualizarGraficoEstoques();
    AtualizarGraficoVendas();
    $("#btnLogin").click(function () {
        ExibirPainelDeLogin();
    });


});


function ExibirPainelDeLogin() {
    Swal.fire({
        title: 'Submit your Github username',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Logar',
        showLoaderOnConfirm: true,
        preConfirm: (login) => {
            return fetch(`//api.github.com/users/${login}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error(response.statusText)
                    }
                    return response.json()
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `Request failed: ${error}`
                    )
                })
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: `${result.value.login}'s avatar`,
                imageUrl: result.value.avatar_url
            })
        }
    })
}
