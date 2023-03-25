using Discord;
using Discord.Interactions;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System.Threading.Channels;
using System;
using System.IO;
using Discord.Commands;
using Discord.Rest;
using Discord.API;
using Discord.Webhook;
using Discord.Addons;

namespace DurikBot.Modules;

public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
{

    [SlashCommand("команды","список команд")]
    public async Task SendRichEmbedAsync()
    {
        var embed = new EmbedBuilder
        {
            
            Title = "команды",
            Description = "команды"
        };
        embed.WithFooter(footer => footer.Text = "Время:")
            .WithColor(Color.Magenta)
            .WithTitle("Команды:")
            .WithDescription(Context.User.Username)
            .WithDescription("Команда /профиль - выводит информацию об вашем аккаунте \nКоманда /правила - указывает на канал с правилами \nКоманда /роль - указывает на канал с получением роли\nКоманда /link/ - ссылка на сервер разработчика")
            .WithImageUrl("https://api.creavite.co/out/5xUSTnaHQBr3rplxnc_static.png")
            .WithCurrentTimestamp();

        
        await ReplyAsync(embed: embed.Build());
    }

    [SlashCommand("правила","правила сервера")]
    public async Task Send2RichEmbedAsync()
    {
        var embed = new EmbedBuilder
        {
            // Embed property can be set within object initializer
            Title = "правила",
            Description = "правила"
        };
        // Or with methods
        embed.WithFooter(footer => footer.Text = "Время:")
            .WithColor(Color.Magenta)
            .WithTitle("Правила:")
            .WithDescription(Context.User.Username)
            .WithDescription("Что бы ознакомиться с правилами,\nперейдите в канал: <#1065294860506108005>")
            .WithImageUrl("https://api.creavite.co/out/K062H1YMVAnUrplxiy_static.png")
            .WithCurrentTimestamp();

        //Your embed needs to be built before it is able to be sent
        await ReplyAsync(embed: embed.Build());
    }

    [SlashCommand("навигатор", "все каналы")]
    private async Task Send0RichEmbedAsync()
    {
        var embed = new EmbedBuilder
        {
            // Embed property can be set within object initializer
            Title = "навигатор",
            Description = "навигатор"
        };
        // Or with methods
        embed.WithColor(Color.Magenta)
            .WithTitle("🗺 Навигация по серверу")
            .WithDescription("⭐ **Информационные каналы:**\n\n" +
            "> ┏<#1059950276146114692> Канал с правилами\n" +
            "> ┣<#1069904803137851413> Канал с важной информацией\n" +
            "> ┣<#1059950553083412610> Канал с новостями\n" +
            "> ┣<#1061761310938898493> Канал с навигацией\n" +
            "> ┗<#1069904825745162290> Набор в staff\n\n" +
            "⭐ **Главные каналы:**\n\n" +
            "> ┏<#1070228103504351232> Канал с раздачами\n" +
            "> ┣<#1061763197335511141> Канал со всеми ролями\n" +
            "> ┗<#1071377831633899580> Информация о командах ботов\n\n" +
            "⭐ **Интерфейс каналы:**\n\n" +
            "> ┏<#1074269641498697748> Меню сервера\n" +
            "> ┣<#1074269661820096542> Получение роли\n" +
            "> ┣<#1074269677494218752> Профиль сервера\n" +
            "> ┗<#1074269706594308157> Информация о донате\n\n" +
            "⭐ **Ивент каналы:**\n\n" +
            "> ┏<#1071091237274263583> Новости по ивентам\n" +
            "> ┣<#1071088516932571136> Информация о ивентах\n" +
            "> ┗<#1071088700957671466> Ивент чат\n\n" +
            "⭐ **Чат каналы:**\n\n" +
            "> ┏<#1059951501382008942> Главный чат\n" +
            "> ┣<#1064598539327520809> Ролеплей чат\n" +
            "> ┣<#1059951356858880091> Поиск друзей/тиммейтов\n" +
            "> ┣<#1065719775067643915> Считаем...\n" +
            "> ┣<#1063524154718036088> Канал для использования команд\n" +
            "> ┗<#1073340394433159240> Флуд канал")
            .WithImageUrl("https://cdn.discordapp.com/attachments/1074251613016969247/1074254650389303296/TCMhTuLQW51Vrplydd_static.png");
        //Your embed needs to be built before it is able to be sent
        await ReplyAsync(embed: embed.Build());
    }

    [SlashCommand("роли", "все роли")]
    private async Task Send4RichEmbedAsync()
    {
        var embed = new EmbedBuilder
        {
            // Embed property can be set within object initializer
            Title = "роли",
            Description = "роли"
        };
        // Or with methods
        embed.WithColor(Color.Magenta)
            .WithTitle("🍁 Роли сервера:")
            .WithDescription("💥 **Роли администрации:**\n\n" +
            "> ┏<@&1059947457993248859> ➜ Владелец\n" +
            "> ┣<@&1071396198377848882> ➜ Со-владелец\n" +
            "> ┣<@&1059951389339553874> ➜ Разработчик\n" +
            "> ┣<@&1064266583624667136> ➜ Гл.Администратор\n" +
            "> ┣<@&1069695513026367590> ➜ Старший администратор\n" +
            "> ┣<@&1036610375958921226> ➜ Администратор\n" +
            "> ┣<@&1059952710159441940> ➜ Гл.Куратор\n" +
            "> ┣<@&1069704405902966904> ➜ Куратор\n" +
            "> ┣<@&1069888762634588210> ➜ Модератор\n" +
            "> ┣<@&1069705976829194351> ➜ Саппорт\n" +
            "> ┗<@&1069722185754755122> ➜ Ивент модерация\n\n" +
            "💥 **Особые роли:**\n\n" +
            "> ┏<@&1074311067175501914> ➜ Важные люди\n" +
            "> ┣<@&1071492501489328249> ➜ Спонсор\n" +
            "> ┣<@&1074229459122659339> ➜ Ст.Менеджер\n" +
            "> ┣<@&1074229456228589579> ➜ Ср.Менеджер\n" +
            "> ┣<@&1074229186065076324> ➜ Мл.Менеджер\n" +
            "> ┣<@&1074397084825952308> ➜ Покупатель наших услуг\n" +
            "> ┣<@&1060954170330452058> ➜ Старина\n" +
            "> ┗<@&1059952694749560933> ➜ Продавец\n\n" +
            "💥 **Второстепенные роли:**\n\n" +
            "> ┏<@&1071102952359600229> ➜ Роль богача\n" +
            "> ┣<@&1064870926245699584> ➜ красный\n" +
            "> ┣<@&1064871116906176542> ➜ синий\n" +
            "> ┣<@&1064871252810010644> ➜ бежевый\n" +
            "> ┣<@&1064872477987184731> ➜ фиолетовый\n" +
            "> ┣<@&1064871477222047745> ➜ черный\n" +
            "> ┣<@&1064871947139285002> ➜ зеленый\n" +
            "> ┣<@&1064872242456047626> ➜ желтый\n" +
            "> ┣<@&1064870375567151216> ➜ гендер парень\n" +
            "> ┣<@&1064869964437262346> ➜ гендер девушка\n" +
            "> ┗<@&1060937736346947656> ➜ коммьюнити сервера\n");

        //Your embed needs to be built before it is able to be sent
        await ReplyAsync(embed: embed.Build());
    }

    private string Emoji(string v)
    {
        throw new NotImplementedException();
    }

    [SlashCommand("роль", "получить роль")]
    public async Task Send3RichEmbedAsync()
    {
        var embed = new EmbedBuilder
        {
            // Embed property can be set within object initializer
            Title = "правила",
            Description = "правила"
        };
        // Or with methods
        embed.WithFooter(footer => footer.Text = "Время:")
            .WithColor(Color.Magenta)
            .WithTitle("Роли")
            .WithDescription(Context.User.Username)
            .WithDescription("Что бы получить себе роль,\nперейдите в канал: <#1066332340613287966>")
            .WithCurrentTimestamp();

        //Your embed needs to be built before it is able to be sent
        await ReplyAsync(embed: embed.Build());
    }


    [SlashCommand("эхо", "введите текст для эхо")]
    public async Task Echo(string input)
    {
        await RespondAsync(input);
    }

    [SlashCommand("профиль", "информация об аккаунте")]
    private async Task Info(SocketGuildUser socketGuildUser = null)
    {
        if (socketGuildUser == null)
        {
            var embed = new EmbedBuilder()
            .WithColor(Color.Purple)
            .WithTitle(Context.User.Username)
            .WithDescription("Информация о вашем аккаунте:")
            .WithImageUrl(Context.User.GetAvatarUrl())
            .AddField("Аккаунт айди:", Context.User.Id, true)
            .AddField("Аккаунт создан:", Context.User.CreatedAt, true)
            .AddField("flags:",Context.User.PublicFlags, true);

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
        else
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Purple)
                .WithTitle(socketGuildUser.Username)
                .WithDescription("Информация о вашем аккаунте:")
                .WithImageUrl(socketGuildUser.GetAvatarUrl())
                .AddField("Аккаунт айди:", Context.User.Id, true)
                .AddField("Аккаунт создан:", Context.User.CreatedAt, true)
                .AddField("flags:", Context.User.PublicFlags, true);

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
    public async Task ReactWithEmoteAsync(SocketUserMessage userMsg, string escapedEmote)
    {
        if (Emote.TryParse(escapedEmote, out var emote))
        {
            await userMsg.AddReactionAsync(emote);
        }
    }
}


