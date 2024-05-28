const apiEndpoint = '/api/WasteBins';

async function fetchdata() {
    try {
        const responsex = await fetch(apiEndpoint);

        if (!responsex.ok) {
            throw new Error('For x response not ok.');
        }
        const jsonResponsex = await responsex.json();

        console.info(jsonResponsex);
    } catch (e) {
        console.error("Error occured.")
    }
}

fetchdata();