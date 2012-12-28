; window.AdminModule = (function() {

    var Post = function(model) {
        var model = model || {};
        this.id = model.id;
        this.title = ko.observable(model.title || 'New Post');
        this.content = ko.observable(model.content || '');
        this.timestamp = model.timeStamp || Date.now();
        this.author = model.author || 'Doublewide';
        this.published = model.published || false;
        this.tags = ko.observableArray(model.tags || []);
        this.summary = ko.observable(model.summary || '');
        this.isFeatured = ko.observable(model.isFeatured || false);
    };

    var Tournament = function(model) {
        var model = model || {};

        var games = model.games || [];
        games = _.map(games, function(game) {
            return new Game(game);
        });

        this.id = model.id;
        this.name = ko.observable(model.name || '');
        this.location = ko.observable(model.location || '');
        this.dates = ko.observable(model.dates || Date.now().toString());
        this.games = ko.observableArray(games);
    };

    var Game = function(model) {
        var model = model || {};
        this.opponent = ko.observable(model.opponent || '');
        this.opponentScore = ko.observable(model.opponentScore);
        this.doublewideScore = ko.observable(model.doublewideScore);
    };

    var public = {
        blogViewModel: {
            posts: ko.observableArray([]),
            selectedPost: ko.observable(new Post())
        },

        resultsViewModel: {
            tournaments: ko.observableArray([]),
            selectedTournament: ko.observable(new Tournament())
        },

        mapData: function(data) {
            this.blogViewModel.posts = _.map(data.posts, function(post) {
                return new Post(post);
            });
            
            this.resultsViewModel.tournaments = _.map(data.tournaments, function(tournament) {
                return new Tournament(tournament);
            });
        },

        init: function(bootstrap) {
            if (!bootstrap) return;

            var blogView = $('#blog-admin')[0];
            var resultsView = $('#season-admin')[0];

            $(function() {
                this.mapData(bootstrap);

                ko.applyBindings(this.blogViewModel, blogView);
                ko.applyBindings(this.resultsViewModel, resultsView);
            }.call(this));
        }
    };

    return public;

})();