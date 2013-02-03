$(function ()
{
    // initializes ZeroClipboard
    ZeroClipboard.setMoviePath('ZeroClipboard10.swf');

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

    $(".reportRow").hide();
    $("div[id^='facebookG_']").hide();
    $.each($('.shelvesets-row'), function (index, item)
    {
        $(item).click(function ()
        {
            try
            {
                toggleReportRow(index);
                toggleBlackBorder($(item).parent());
            }
            catch (e)
            {
                alert(e.message);
            }
        });
    });


});

function toggleReportRow(index)
{
    // toggle the row
    var reportRow = $(".reportRow").eq(index);
    if (reportRow.is(':hidden'))
    {
        // follow the link in the hidden row and populate the review
        var link = reportRow.find('.hidden-report-link');
        if (link.length)
        {
            $("#facebookG_" + index).show();
            $.ajax({
                async: true,
                type: "GET",
                url: link.attr('href'),
                success: function (report)
                {
                    // replace the link with the report so that we don't do it again
                    link.replaceWith(report);
                    reportRow.fadeToggle('fast');
                    $("#facebookG_" + index).hide();
                }
            });
        }
        else
        {
            reportRow.fadeToggle('fast');
        }
    }
    else
    {
        reportRow.fadeToggle('fast');
    }
}

function toggleBlackBorder(item)
{
    if ($(item).hasClass('black-border'))
    {
        $(item).removeClass('black-border');
    }
    else
    {
        $(item).addClass('black-border');    
    }    
}

function toClipboard(index, container)
{
    var clip = new ZeroClipboard.Client();
    clip.setHandCursor(false);

    // set the text
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

    var shelvesetsName = $.trim($(".shelvesets-row").eq(index).children("td").eq(0).text());
    clip.addEventListener('complete', function (client, text)
    {
        //alert('Record copied to clipboard.');	                
        sendMail($.cookie('emailAddress'), shelvesetsName);
    });

    var child = container.children("div[id^='d_clip_button_']");
    clip.glue(child.attr('id'), container.attr('id'));
}

function sendMail(emailAddress, subject)
{
    location.href = 'mailto:' + emailAddress + '?subject=Code review for shelveset [' + subject + ']&body=%0D%0DPlease hit paste.%0D%0D';
}