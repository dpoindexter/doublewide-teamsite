(function () {

    var root = this;
    var dwtx = root.dwtx = root.dwtx || {};

    //Posts
    var PostModel = Backbone.Model.extend({

    });

    var PostCollection = Backbone.Collection.extend({
        model: PostModel
    });

    //Tournaments
    var TournamentModel = Backbone.Model.extend({

    });

    var TournamentCollection = Backbone.Collection.extend({

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

        posts: null,
        postsTemplate: null,
        postsContainer: null,

        initialize: function () {
            this.posts = new PostCollection(this.options.postsData);
            this.postsTemplate = _.template($('#posts-template').html());
            this.postsContainer = this.$('#posts-template-container');
            this.render();
        },

        render: function () {
            var modelData = this.posts.toJSON();
            var compiled = this.postsTemplate({ posts: modelData });
            this.postsContainer.html(compiled);
        }

    });

    var SeasonEditor = Backbone.View.extend({

        tournaments: null,

        initialize: function () {
            this.tournaments = new TournamentCollection(viewData.tournaments);
        }

    });

    dwtx.Admin = {
        init: function () {
            console.log('starting application');
            this.Blog = new BlogEditor({ el: $('#blog-editor'), postsData: this.viewData.posts });
            this.Season = new SeasonEditor();
        }
    };

}).call(this);