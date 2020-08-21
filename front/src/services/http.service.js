
export const http = {
  get,
  post,
};

async function handleResponseError(response) {
    if (response.ok) {
      if (response.status === 204) return;
      return response.json();
    }
    if (response.status === 409)
      throw("The data was modified in the meantime. Please refresh the page.");
    if (response.status === 401) {
      throw("Unathorized");
    }
  
    if (response.status === 400) {
      let error = await response.json();
      throw error;
    }
    throw(`Unexpected Error Have occured ${response.status} - ${response.url}`);
  }

function get(url) {
    let request = new Request(url);
    let request_options = {
      method: "GET",
      mode: "cors",
      headers: {
        "X-Authentication": localStorage.getItem("token"),
      },
    };
    return fetch(request, request_options).then((response) => {
      return handleResponseError(response);
    });
  }

  function post(url, body) {

    console.log(url)
    console.log(body)
    let request = new Request(url);
  
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    };

    return fetch(request, requestOptions).then((response) => {
      return handleResponseError(response);
    });
  }

