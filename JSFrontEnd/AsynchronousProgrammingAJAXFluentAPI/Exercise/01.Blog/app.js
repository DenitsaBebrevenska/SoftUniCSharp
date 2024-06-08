function attachEvents() {
  let loadPostsButton = document.getElementById("btnLoadPosts");
  let postSelectMenuElement = document.getElementById("posts");
  let viewPostButton = document.getElementById("btnViewPost");
  let postsUrl = "http://localhost:3030/jsonstore/blog/posts";
  let commentsUrl = "http://localhost:3030/jsonstore/blog/comments";
  let allCurrentPosts;

  loadPostsButton.addEventListener("click", async function () {
    try {
      const response = await fetch(postsUrl);
      const data = await response.json();
      allCurrentPosts = data;
      let fragment = document.createDocumentFragment();

      for (const postObj in data) {
        let postBody = data[postObj].title;
        let newOption = document.createElement("option");
        newOption.value = postObj;
        newOption.textContent = postBody;
        fragment.appendChild(newOption);
      }

      postSelectMenuElement.appendChild(fragment);
    } catch (err) {
      console.log(err);
    }
  });

  viewPostButton.addEventListener("click", async function () {
    let postBodyElement = document.getElementById("post-body");
    let postTitle = document.getElementById("post-title");
    let postCommentsElement = document.getElementById("post-comments");
    let selectedPostId = postSelectMenuElement.value;
    let selectedPost = allCurrentPosts[selectedPostId];
    postTitle.textContent = selectedPost.title;
    postBodyElement.textContent = selectedPost.body;

    try {
      const response = await fetch(commentsUrl);
      const data = await response.json();
      let selectedPostComments = Object.values(data).filter(
        (comment) => comment.postId === selectedPostId
      );
      let fragment = document.createDocumentFragment();
      selectedPostComments.forEach((comment) => {
        let newLiItem = document.createElement("li");
        newLiItem.textContent = comment.text;
        fragment.appendChild(newLiItem);
      });

      postCommentsElement.appendChild(fragment);
    } catch (err) {
      console.log(err);
    }
  });
}

attachEvents();
