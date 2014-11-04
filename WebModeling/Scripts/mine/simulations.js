var xpan = xpan || {};
xpan.webModeling = xpan.webModeling || {};
xpan.webModeling.simulations = xpan.webModeling.simulations || {
    uri: 'api/simulations',

    getAll: function() {

    },

    create: function() {

    },

    init: function() {
        $(document).ready(function () {
            $('#showsimulations').click(function () {
                $.getJSON(xpan.webModeling.simulations.uri).done(function (data) {
                    $.each(data, function (key, item) {
                        $('<li>', { text: item.Name }).appendTo($('#allsimulations'));
                    });
                    $('#all-simulation-form').dialog("open");
                });
            });

            $('#all-simulation-form').dialog({ autoOpen: false, modal: true});
        });
    }
};
