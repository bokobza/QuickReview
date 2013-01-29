$(function ()
{
    $(".settings").click(function (event)
    {
        // read the cookie
        $("input#EmailRecipient").val($.cookie('emailAddress'));
        event.preventDefault();
        $("fieldset#settings_menu").toggle();
        event.stopPropagation();
    });

    $("fieldset#settings_menu").click(function (event)
    {
        event.stopPropagation();
    });

    $(document).click(function ()
    {
        if ($("fieldset#settings_menu").is(":visible"))
        {
            // save the cookie and hide the menu
            $.cookie('emailAddress', $("input#EmailRecipient").val(), { expires: 365, path: '/' });
            $("fieldset#settings_menu").hide();
        }
    });
});


$(function ()
{
    $(".reportRow").hide();
    var shelvesetRows = $('.shelvesets-row');
    $.each(shelvesetRows, function (index, item)
    {
        var shelvesetRow = $(this);
        shelvesetRow.click(function ()
        {
            // toggle the row
            var reportRow = $(".reportRow").eq(index);
            if (reportRow.is(':hidden'))
            {
                // follow the link in the hidden row and populate the review
                var link = reportRow.find('.hidden-report-link');
                if (link.length)
                {
                    reportRow.find('.reportDiv').load(link.attr('href'));
                }
            }

            reportRow.fadeToggle('fast');
        });
    });
});

function init_zeroclipboard()
{
    var containers = $("div[id^='d_clip_container_']");
    $.each(containers, function (index, item)
    {
        var a = $(this);
        var child = a.children("div[id^='d_clip_button_']");
        var shelvesetsName = $.trim($(".shelvesets-row").eq(index).children("td").eq(0).text());

        var clip = new ZeroClipboard.Client();
        ZeroClipboard.setMoviePath('ZeroClipboard10.swf');
        clip.setHandCursor(true);
        clip.glue(child.attr('id'), a.attr('id'));

        clip.addEventListener('load', function (client)
        {
            //alert("Flash movie loaded and ready.");
        });

        clip.addEventListener('mouseDown', function (client)
        {
            // get the review	        
            var reportRow = $(".reportRow").eq(index);
            var link = reportRow.find('.hidden-report-link');
            // if the link to the report is here then get the report
            // otherwise it means the report has already been fetched
            if (link.length)
            {
                $.ajax({
                    async: false,
                    type: "GET",
                    url: link.attr('href'),
                    success: function (report)
                    {
                        // replace the link with the report so that we don't do it again
                        link.replaceWith(report);
                        clip.setText(report);
                    }
                });
            }
            else
            {
                // if the .reportdiv is already populated, simply add it to the clip.
                clip.setText(reportRow.find('.reportDiv').html());
            }
        });

        clip.addEventListener('complete', function (client, text)
        {
            //alert('Record copied to clipboard.');	        
            sendMail($.cookie('emailAddress'), shelvesetsName);
        });
    });
}

function sendMail(emailAddress, subject)
{
    location.href = 'mailto:' + emailAddress + '?subject=Code review for shelveset [' + subject + ']&body=%0D%0DPlease hit paste.%0D%0D';
}

/*
$(function ()
{
    var anchors = $('a.email');
    $.each(anchors, function (index, item)
    {
        var a = $(this);
        var href = a.attr('href');
        a.attr('data-href', href);
        a.attr('href', '#');
        a.bind('click', function ()
        {
            var x = $(this);
            var emailAddress = $.cookie('emailAddress');
            x.attr('data-href', x.attr('data-href') + '&emailRecipient=' + emailAddress);
            $('#myForm').get(0).setAttribute('action', x.attr('data-href'));
            $('#myForm').submit();
        });
    });
});
*/