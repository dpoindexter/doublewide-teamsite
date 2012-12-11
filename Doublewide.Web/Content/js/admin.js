; window.AdminModule = (function() {

    var Post = function(model) {
        var model = model || {};
        this.title = ko.observable(model.title || 'New Post');
        this.content = ko.observable(model.content || '');
        this.timeStamp = model.timeStamp || Date.now();
        this.author = model.author || 'Doublewide';
        this.published = model.published || false;
        this.tags = ko.observableArray(model.tags || []);
        this.summary = ko.observable(model.summary || '');
        this.isFeatured = ko.observable(model.isFeatured || false);
    };

    var Tournament = function(model) {
        var model = model || {};
        this.name = ko.observable(model.name || '');
        this.location = ko.observable(model.location || '');
        this.startDate = ko.observable(model.startDate || Date.now());
        this.endDate = ko.observable(model.endDate || Date.now());
        this.games = ko.observableArray(model.games || []);
    };

    var Game = function(model) {
        var model = model || {};
        this.opponent = ko.observable(model.opponent || '');
        this.opponentScore = ko.observable(model.opponentScore);
        this.doublewideScore = ko.observable(model.doublewideScore);
    };

    var public = {
        blogViewModel: {
            scope: null,
            posts: ko.observableArray([]),
            selectedPost: ko.observable(new Post())
        },

        resultsViewModel: {
            scope: null,
            tournaments: ko.observableArray([])
        },

        mapData: function(data) {
            this.blogViewModel.posts = _.map(data.posts, function(post) {
                return new Post(post);
            });
            
            this.resultsViewModel.posts = _.map(data.tournaments, function(tournament) {
                return new Tournament(tournament);
            });
        },

        init: function(bootstrap) {
            if (!bootstrap) return;

            $(function() {
                console.log(this);
                this.blogViewModel.scope = $('#blog-admin')[0];
                this.resultsViewModel.scope = $('#season-admin')[0];

                this.mapData(bootstrap);

                ko.applyBindings(this.blogViewModel, this.blogViewModel.scope);
                ko.applyBindings(this.resultsViewModel, this.resultsViewModel.scope);
            }.call(this));
        }
    };

    return public;

})();