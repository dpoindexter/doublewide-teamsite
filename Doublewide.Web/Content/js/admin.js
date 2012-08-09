(function () {

    var root = this;
    var dwtx = root.dwtx = root.dwtx || {};

    var dispatcher = _.clone(Backbone.Events);

    //Posts
    var PostModel = Backbone.Model.extend({
        idAttribute: "Id"
    });

    var PostCollection = Backbone.Collection.extend({
        model: PostModel
    });

    var PostsView = Backbone.View.extend({

        el: '#posts-template-container',
        template: null,

        events: {
            'click .blog-post': "triggerSelectPost"
        },

        initialize: function () {
            _.bindAll(this, "triggerSelectPost");

            this.template = _.template($('#posts-template').html());
        },

        render: function () {
            var compiled = this.template({ posts: this.collection.toJSON() });
            this.$el.html(compiled);
        },

        triggerSelectPost: function (event) {
            console.log("hey!");
            dispatcher.trigger("select:post", event.target);
        }
    });

    var EditPostView = Backbone.View.extend({

        el: "#blog-editor",

        initialize: function () {
            var self = this;
            _.bindAll(this, "handleSelectPost");

            dispatcher.on("select:post", function (target) {
                self.handleSelectPost(target);
            });
        },

        render: function () {
            if (!this.model) return this;
            this.$('h2').html(this.model.get("Title"));
            return this;
        },

        handleSelectPost: function (target) {
            var id = $(target).parent(".blog-post").data("id");
            this.model = this.collection.get(id);
            this.render();
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
    var BlogAdmin = Backbone.View.extend({

        el: '#blog-admin',

        posts: null,
        postsView: null,
        editView: null,

        initialize: function () {
            this.postsView = new PostsView({ collection: this.collection });
            this.editView = new EditPostView({ collection: this.collection, model: new PostModel() });
            this.render();
        },

        render: function () {
            this.postsView.render();
        }

    });

    var SeasonAdmin = Backbone.View.extend({

    });

    dwtx.Admin = {
        init: function () {
            this.Blog = new BlogAdmin({ collection: new PostCollection(this.viewData.posts) });
            this.Season = new SeasonAdmin({ collection: new TournamentCollection(this.viewData.tournaments) });
        }
    };

}).call(this);