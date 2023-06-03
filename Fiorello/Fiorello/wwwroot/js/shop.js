$(document).ready(function () {

   
    $(document).on("click", ".show-more-btn", function () { 

        let parent = $("#parent-elem");
        let skipCount = $(parent).children().length;
        let productCount = $("#products").attr("data-count");

        $.ajax({
            url: `shop/showmoreorless?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                $(parent).append(res);
                let skipCount = $(parent).children().length;
                if (skipCount >= productCount) {
                    $(".show-more-btn").addClass("d-none")
                    $(".show-less-btn").removeClass("d-none")
                }
            }
        })
    })


    $(document).on("click", ".show-less-btn", function () {

        let parent = $("#parent-elem");
        let skipCount = 0;
        $.ajax({
            url: `shop/showmoreorless?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                $(parent).empty();
                $(parent).append(res);
                $(".show-less-btn").addClass("d-none")
                $(".show-more-btn").removeClass("d-none")
                
            }
        })
    })





})