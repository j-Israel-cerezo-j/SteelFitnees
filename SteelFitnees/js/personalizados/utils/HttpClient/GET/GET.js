function get(callback, url) {
    return new Promise((resolve,reject) => {        
        const table = fetch(url);
        table
        .then((resp) => resp.json())
        .then((resp) => {            
            resolve(callback(resp.data.recoverData));
        });
    })
}
