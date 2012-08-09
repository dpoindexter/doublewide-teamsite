(function () {

    var root = this;
    var dwtx = root.dwtx = root.dwtx || {};

    //Posts
    var PostModel = Backbone.Model.extend();

    var PostCollection = Backbone.Collection.extend({
        model: PostModel
    });

    var PostsView = Backbone.View.extend({
        
        el: '#posts-template-container',
        template: null,

        initialize: function () {
            this.template = _.template($('#posts-template').html());
        },

        render: function () {
            var compiled = this.template({ posts: this.collection.toJSON() });
            this.$el.html(compiled);
        }

    });

    //Tournaments
    var TournamentModel = Backbone.Model.extend();

    var TournamentCollection = Backbone.Collection.extend({
        model: TournamentModel
    });

    var TournamentView = Backbone.View.extend({

    });

    //Games
    var GameModel = Backbone.Model.extend({

    });

    var GameCollection = Backbone.Collection.extend({

    });

    var GameView = Backbone.View.extend({

    });

    //Controller views
    var BlogEditor = Backbone.View.extend({

        el: '#blog-editor',

        posts: null,
        postsView: null,

        initialize: function () {
            this.postsView = new PostsView({ el: $('#posts-template-container'), collection: this.collection });
            this.render();
        },

        render: function () {
            this.postsView.render();
        }

    });

    var SeasonEditor = Backbone.View.extend({

    });

    dwtx.Admin = {
        init: function () {
            this.Blog = new BlogEditor({ collection: new PostCollection(this.viewData.posts) });
            this.Season = new SeasonEditor({ collection: new TournamentCollection(this.viewData.tournaments) });
        }
    };

}).call(this);