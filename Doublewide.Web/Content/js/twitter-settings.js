$(function () {
    $("#twitter-feed").tweet({
        username: 'doublewidetx',
        count: 6,
        avatar_size: 32,
        template: "{avatar}{join}{text}{time}"
    });
});