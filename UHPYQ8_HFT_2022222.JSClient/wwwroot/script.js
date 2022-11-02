let publishers = [];
let game = [];
let platform = [];
let connection;
let publisherIdToUpdate = -1;
let gameIdToUpdate = -1;
let platformIdToUpdate = -1;
getdatagame();
getdata();
getdataplatform();
setupSignalR();

//Connection
async function start(connection) {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
function setupSignalR() {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:51783/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PublisherCreated", (user, message) => {
        getdata();
    });

    connection.on("PublisherDeleted", (user, message) => {
        getdata();
    });

    connection.on("PublisherUpdated", (user, message) => {
        getdata();
    });

    connection.on("GameCreated", (user, message) => {
        getdatagame();
    });

    connection.on("GameDeleted", (user, message) => {
        getdatagame();
    });

    connection.on("GameUpdated", (user, message) => {
        getdatagame();
    });

    connection.on("PlatformCreated", (user, message) => {
        getdataplatform();
    });

    connection.on("PlatformDeleted", (user, message) => {
        getdataplatform();
    });

    connection.on("PlatformUpdated", (user, message) => {
        getdataplatform();
    });

    connection.onclose(async () => {
        await start();
    });
    start(connection);
}

//Publisher
async function getdata() {
    await fetch('http://localhost:51783/publisher')
        .then(x => x.json())
        .then(y => {
            publishers = y;
            /*console.log(publishers);*/
            display();
        });
}
function display() {
    document.getElementById('resultarea').innerHTML = "";
    publishers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr>" +
            "<td> " + t.publisherId + "</td>"+
        "<td> " + t.publisherName + "</td>" +
        `<td><button type="button" onclick="remove('${t.publisherId}')">Delete</button>
            <button type="button" onclick="showupdate('${t.publisherId}')">Update</button></td>` +
            "</tr>";
    });
}
function create() {
    let name = document.getElementById('publishername').value;
    fetch('http://localhost:51783/publisher', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                publisherName: name
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function remove(id) {
    fetch('http://localhost:51783/publisher/'+id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function update() {
    document.getElementById("updateformdiv").style.display = 'none';
    let name = document.getElementById('publishernametoupdate').value;
    fetch('http://localhost:51783/publisher', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                publisherName: name, publisherId: publisherIdToUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showupdate(id) {
    document.getElementById('publishernametoupdate').value = publishers.find(t => t['publisherId'] == id)['publisherName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    publisherIdToUpdate = id;
}
//Game
async function getdatagame() {
    await fetch('http://localhost:51783/game')
        .then(x => x.json())
        .then(y => {
            game = y;
/*            console.log(game);*/
            displaygame();
        });
}
function displaygame() {
    document.getElementById('resultareagame').innerHTML = "";
    game.forEach(t => {
        document.getElementById('resultareagame').innerHTML +=
            "<tr>" +
            "<td> " + t.gameId + "</td>" +
            "<td> " + t.title + "</td>" +
            "<td> " + t.price + "</td>" +
        "<td> " + t.platformId + "</td>" +
        `<td><button type="button" onclick="removegame('${t.gameId}')">Delete</button>
            <button type="button" onclick="showupdategame('${t.gameId}')">Update</button></td>` +
            "</tr>";
    });
}
function creategame(){
    let title = document.getElementById('gametitle').value;
    let platformidgame = document.getElementById('platformidgame').value;
    let pricegame = document.getElementById('pricegame').value;
    fetch('http://localhost:51783/game', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                title: title,
                platformId: platformidgame,
                price: pricegame
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatagame();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function removegame(id) {
    fetch('http://localhost:51783/game/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatagame();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function updategame() {
    document.getElementById("updateformdivgame").style.display = 'none';
    let titleg = document.getElementById('gametitletoupdate').value;
    let price = document.getElementById('pricegametoupdate').value;
    let platform = document.getElementById('platformidgametoupdate').value;
    fetch('http://localhost:51783/game', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                gameId: gameIdToUpdate,
                title: titleg,
                price: price,
                platformId: platform
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatagame();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showupdategame(id) {
    document.getElementById('gametitletoupdate').value = game.find(t => t['gameId'] == id)['title'];
    document.getElementById('pricegametoupdate').value = game.find(t => t['gameId'] == id)['price'];
    var x = game.find(t => t['gameId'] == id)['platformId'];
    document.getElementById('platformidgametoupdate').value = x;
    document.getElementById('updateformdivgame').style.display = 'flex';
    gameIdToUpdate = id;
}
//Platform
async function getdataplatform() {
    await fetch('http://localhost:51783/platform')
        .then(x => x.json())
        .then(y => {
            platform = y;
            console.log(platform);
            displayplatform();
        });
}
function displayplatform() {
    document.getElementById('resultareaplatform').innerHTML = "";
    platform.forEach(t => {
        document.getElementById('resultareaplatform').innerHTML +=
            "<tr>" +
            "<td> " + t.platformId + "</td>" +
            "<td> " + t.platformName + "</td>" +
            `<td><button type="button" onclick="removeplatform('${t.platformId}')">Delete</button>
            <button type="button" onclick="showupdateplatform('${t.platformId}')">Update</button></td>` +
            "</tr>";
    });
}
function createplatform() {
    let name = document.getElementById('platformname').value;
    fetch('http://localhost:51783/platform', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                platformName: name,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdataplatform();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function removeplatform(id) {
    fetch('http://localhost:51783/platform/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            displayplatform();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function updateplatform() {
    document.getElementById("updateformdivplatform").style.display = 'none';
    let name = document.getElementById('platformnametoupdate').value;
    fetch('http://localhost:51783/platform', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                platformId: platformIdToUpdate,
                platformName: name,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdataplatform();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showupdateplatform(id) {
    document.getElementById('gametitletoupdate').value = game.find(t => t['gameId'] == id)['title'];
    document.getElementById('pricegametoupdate').value = game.find(t => t['gameId'] == id)['price'];
    var x = platform.find(t => t['platformId'] == id)['platformName'];
    document.getElementById('platformnametoupdate').value = x;
    document.getElementById('updateformdivplatform').style.display = 'flex';
    platformIdToUpdate = id;
}